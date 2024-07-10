﻿using System.Collections;
using Backbone.DevelopmentKit.Identity.ValueObjects;
using Backbone.Modules.Messages.Domain.Entities;
using Backbone.Modules.Messages.Domain.Tests.TestHelpers;
using Backbone.UnitTestTools.Extensions;
using FluentAssertions;
using Xunit;

namespace Backbone.Modules.Messages.Domain.Tests.Messages;

public class DecomposeForTests
{
    public static readonly IdentityAddress ANONYMIZED_ADDRESS = IdentityAddress.GetAnonymized("localhost");

    [Theory]
    [ClassData(typeof(TestDataWithAllCases))]
    public void SetsMessageIsHiddenForX(TestInput input, TestOutput output)
    {
        // Arrange
        var recipient1 = input.Message.Recipients.First();
        var recipient2 = input.Message.Recipients.Second();

        // Act
        input.Message.DecomposeFor(input.Decomposer, input.Peer, ANONYMIZED_ADDRESS);

        // Assert
        recipient1.MessageIsHiddenForRecipient.Should().Be(output.R1_HiddenForRecipient);
        recipient1.MessageIsHiddenForSender.Should().Be(output.R1_HiddenForSender);

        recipient2.MessageIsHiddenForRecipient.Should().Be(output.R2_HiddenForRecipient);
        recipient2.MessageIsHiddenForSender.Should().Be(output.R2_HiddenForSender);
    }

    [Fact]
    public void When_first_participant_of_relationship_decomposes__recipient_does_not_get_anonymized()
    {
        // Arrange
        var message = TestData.CreateMessageWithTwoRecipients();
        var recipient1 = message.Recipients.First();
        var recipient2 = message.Recipients.Second();
        var sender = message.CreatedBy;

        // Act
        message.DecomposeFor(sender, recipient1.Address, ANONYMIZED_ADDRESS);

        // Assert
        recipient1.Address.Should().NotBe(ANONYMIZED_ADDRESS);
        recipient2.Address.Should().NotBe(ANONYMIZED_ADDRESS);
    }

    [Fact]
    public void When_second_participant_of_relationship_decomposes__recipient_gets_anonymized()
    {
        // Arrange
        var message = TestData.CreateMessageWithTwoRecipients();
        var recipient1 = message.Recipients.First();
        var recipient2 = message.Recipients.Second();
        var sender = message.CreatedBy;

        message.DecomposeFor(recipient1.Address, sender, ANONYMIZED_ADDRESS);

        // Act
        message.DecomposeFor(sender, recipient1.Address, ANONYMIZED_ADDRESS);

        // Assert
        recipient1.Address.Should().Be(ANONYMIZED_ADDRESS);
        recipient2.Address.Should().NotBe(ANONYMIZED_ADDRESS);
    }

    // [Theory]
    // [ClassData(typeof(TestDataWhereOnlyR1IsFullyDecomposed))]
    // public void AnonymizesRecipientAfterFirstRelationshipIsFullyDecomposed(TestInput input, TestOutput output)
    // {
    //     // Arrange
    //     var message = TestData.CreateMessageWithTwoRecipients();
    //     if (input.Recipient1HasAlreadyDecomposedRelationshipWithSender)
    //     {
    //         message.ParticipantDecomposedRelationship(message.Recipients.First().Address, message.CreatedBy, _anonymizedAddress);
    //     }
    //
    //     if (input.Recipient2HasAlreadyDecomposedRelationshipWithSender)
    //         message.ParticipantDecomposedRelationship(message.Recipients.Second().Address, message.CreatedBy, _anonymizedAddress);
    //
    //     if (input.SenderHasAlreadyDecomposedRelationshipWithRecipient1)
    //         message.ParticipantDecomposedRelationship(message.CreatedBy, message.Recipients.First().Address, _anonymizedAddress);
    //
    //     if (input.SenderHasAlreadyDecomposedRelationshipWithRecipient2)
    //         message.ParticipantDecomposedRelationship(message.CreatedBy, message.Recipients.Second().Address, _anonymizedAddress);
    //
    //     var senderAddress = message.CreatedBy;
    //     var recipient1 = message.Recipients.First();
    //     var recipient2 = message.Recipients.Second();
    //
    //     var decomposer = input.Decomposer switch
    //     {
    //         Participant.Sender => senderAddress,
    //         Participant.Recipient1 => recipient1.Address,
    //         Participant.Recipient2 => recipient2.Address,
    //         _ => throw new Exception()
    //     };
    //
    //     IdentityAddress peer;
    //
    //     if (decomposer == senderAddress)
    //     {
    //         peer = input.RelationshipTo switch
    //         {
    //             Participant.Recipient1 => recipient1.Address,
    //             Participant.Recipient2 => recipient2.Address,
    //             _ => throw new Exception()
    //         };
    //     }
    //     else
    //         peer = senderAddress;
    //
    //     // Act
    //     message.ParticipantDecomposedRelationship(decomposer, peer, _anonymizedAddress);
    //
    //     // Assert
    //     recipient1.Address.Should().Be(_anonymizedAddress);
    //     recipient2.Address.Should().NotBe(_anonymizedAddress);
    // }
}

public enum Participant
{
    Sender,
    Recipient1,
    Recipient2
}

// ReSharper disable once UnusedAutoPropertyAccessor.Global - The Id property is only used to identify the test case in the test output
public record TestInput
{
    public TestInput(int id,
        Participant decomposer,
        Participant relationshipTo,
        bool senderHasAlreadyDecomposedRelationshipWithRecipient1,
        bool recipient1HasAlreadyDecomposedRelationshipWithSender,
        bool senderHasAlreadyDecomposedRelationshipWithRecipient2,
        bool recipient2HasAlreadyDecomposedRelationshipWithSender)
    {
        Id = id;

        Message = TestData.CreateMessageWithTwoRecipients();

        Decomposer = decomposer switch
        {
            Participant.Sender => Message.CreatedBy,
            Participant.Recipient1 => Message.Recipients.First().Address,
            Participant.Recipient2 => Message.Recipients.Second().Address,
            _ => throw new Exception()
        };

        if (Decomposer == Message.CreatedBy)
        {
            Peer = relationshipTo switch
            {
                Participant.Recipient1 => Message.Recipients.First().Address,
                Participant.Recipient2 => Message.Recipients.Second().Address,
                _ => throw new Exception()
            };
        }
        else
            Peer = Message.CreatedBy;

        if (recipient1HasAlreadyDecomposedRelationshipWithSender)
            Message.DecomposeFor(Message.Recipients.First().Address, Message.CreatedBy, DecomposeForTests.ANONYMIZED_ADDRESS);
        if (recipient2HasAlreadyDecomposedRelationshipWithSender)
            Message.DecomposeFor(Message.Recipients.Second().Address, Message.CreatedBy, DecomposeForTests.ANONYMIZED_ADDRESS);
        if (senderHasAlreadyDecomposedRelationshipWithRecipient1)
            Message.DecomposeFor(Message.CreatedBy, Message.Recipients.First().Address, DecomposeForTests.ANONYMIZED_ADDRESS);
        if (senderHasAlreadyDecomposedRelationshipWithRecipient2)
            Message.DecomposeFor(Message.CreatedBy, Message.Recipients.Second().Address, DecomposeForTests.ANONYMIZED_ADDRESS);
    }


    public int Id { get; init; }
    public Message Message { get; }
    public IdentityAddress Decomposer { get; }
    public IdentityAddress Peer { get; }
}

// ReSharper disable InconsistentNaming
public record TestOutput(bool R1_HiddenForSender, bool R1_HiddenForRecipient, bool R2_HiddenForSender, bool R2_HiddenForRecipient);
// ReSharper restore InconsistentNaming

public class TestDataWithAllCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [new TestInput(0, Participant.Sender, Participant.Recipient1, false, false, false, false), new TestOutput(true, false, false, false)];
        yield return [new TestInput(1, Participant.Recipient1, Participant.Recipient1, false, false, false, false), new TestOutput(false, true, false, false)];
        yield return [new TestInput(2, Participant.Sender, Participant.Recipient2, false, false, false, false), new TestOutput(false, false, true, false)];
        yield return [new TestInput(3, Participant.Recipient2, Participant.Recipient2, false, false, false, false), new TestOutput(false, false, false, true)];
        yield return [new TestInput(5, Participant.Recipient1, Participant.Recipient1, true, false, false, false), new TestOutput(true, true, false, false)];
        yield return [new TestInput(6, Participant.Sender, Participant.Recipient2, true, false, false, false), new TestOutput(true, false, true, false)];
        yield return [new TestInput(7, Participant.Recipient2, Participant.Recipient2, true, false, false, false), new TestOutput(true, false, false, true)];
        yield return [new TestInput(8, Participant.Sender, Participant.Recipient1, false, false, true, false), new TestOutput(true, false, true, false)];
        yield return [new TestInput(9, Participant.Recipient1, Participant.Recipient1, false, false, true, false), new TestOutput(false, true, true, false)];
        yield return [new TestInput(11, Participant.Recipient2, Participant.Recipient2, false, false, true, false), new TestOutput(false, false, true, true)];
        yield return [new TestInput(13, Participant.Recipient1, Participant.Recipient1, true, false, true, false), new TestOutput(true, true, true, false)];
        yield return [new TestInput(15, Participant.Recipient2, Participant.Recipient2, true, false, true, false), new TestOutput(true, false, true, true)];
        yield return [new TestInput(16, Participant.Sender, Participant.Recipient1, false, true, false, false), new TestOutput(true, true, false, false)];
        yield return [new TestInput(18, Participant.Sender, Participant.Recipient2, false, true, false, false), new TestOutput(false, true, true, false)];
        yield return [new TestInput(19, Participant.Recipient2, Participant.Recipient2, false, true, false, false), new TestOutput(false, true, false, true)];
        yield return [new TestInput(22, Participant.Sender, Participant.Recipient2, true, true, false, false), new TestOutput(true, true, true, false)];
        yield return [new TestInput(23, Participant.Recipient2, Participant.Recipient2, true, true, false, false), new TestOutput(true, true, false, true)];
        yield return [new TestInput(24, Participant.Sender, Participant.Recipient1, false, true, true, false), new TestOutput(true, true, true, false)];
        yield return [new TestInput(27, Participant.Recipient2, Participant.Recipient2, false, true, true, false), new TestOutput(false, true, true, true)];
        yield return [new TestInput(31, Participant.Recipient2, Participant.Recipient2, true, true, true, false), new TestOutput(true, true, true, true)];
        yield return [new TestInput(32, Participant.Sender, Participant.Recipient1, false, false, false, true), new TestOutput(true, false, false, true)];
        yield return [new TestInput(33, Participant.Recipient1, Participant.Recipient1, false, false, false, true), new TestOutput(false, true, false, true)];
        yield return [new TestInput(34, Participant.Sender, Participant.Recipient2, false, false, false, true), new TestOutput(false, false, true, true)];
        yield return [new TestInput(37, Participant.Recipient1, Participant.Recipient1, true, false, false, true), new TestOutput(true, true, false, true)];
        yield return [new TestInput(38, Participant.Sender, Participant.Recipient2, true, false, false, true), new TestOutput(true, false, true, true)];
        yield return [new TestInput(40, Participant.Sender, Participant.Recipient1, false, false, true, true), new TestOutput(true, false, true, true)];
        yield return [new TestInput(41, Participant.Recipient1, Participant.Recipient1, false, false, true, true), new TestOutput(false, true, true, true)];
        yield return [new TestInput(45, Participant.Recipient1, Participant.Recipient1, true, false, true, true), new TestOutput(true, true, true, true)];
        yield return [new TestInput(48, Participant.Sender, Participant.Recipient1, false, true, false, true), new TestOutput(true, true, false, true)];
        yield return [new TestInput(50, Participant.Sender, Participant.Recipient2, false, true, false, true), new TestOutput(false, true, true, true)];
        yield return [new TestInput(54, Participant.Sender, Participant.Recipient2, true, true, false, true), new TestOutput(true, true, true, true)];
        yield return [new TestInput(56, Participant.Sender, Participant.Recipient1, false, true, true, true), new TestOutput(true, true, true, true)];
        // yield return [new TestInput(4, Participant.Sender, Participant.Recipient1, true, false, false, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(10, Participant.Sender, Participant.Recipient2, false, false, true, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(12, Participant.Sender, Participant.Recipient1, true, false, true, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(14, Participant.Sender, Participant.Recipient2, true, false, true, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(17, Participant.Recipient1, Participant.Recipient1, false, true, false, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(20, Participant.Sender, Participant.Recipient1, true, true, false, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(21, Participant.Recipient1, Participant.Recipient1, true, true, false, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(25, Participant.Recipient1, Participant.Recipient1, false, true, true, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(26, Participant.Sender, Participant.Recipient2, false, true, true, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(28, Participant.Sender, Participant.Recipient1, true, true, true, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(29, Participant.Recipient1, Participant.Recipient1, true, true, true, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(30, Participant.Sender, Participant.Recipient2, true, true, true, false), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(35, Participant.Recipient2, Participant.Recipient2, false, false, false, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(36, Participant.Sender, Participant.Recipient1, true, false, false, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(39, Participant.Recipient2, Participant.Recipient2, true, false, false, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(42, Participant.Sender, Participant.Recipient2, false, false, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(43, Participant.Recipient2, Participant.Recipient2, false, false, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(44, Participant.Sender, Participant.Recipient1, true, false, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(46, Participant.Sender, Participant.Recipient2, true, false, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(47, Participant.Recipient2, Participant.Recipient2, true, false, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(49, Participant.Recipient1, Participant.Recipient1, false, true, false, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(51, Participant.Recipient2, Participant.Recipient2, false, true, false, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(52, Participant.Sender, Participant.Recipient1, true, true, false, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(53, Participant.Recipient1, Participant.Recipient1, true, true, false, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(55, Participant.Recipient2, Participant.Recipient2, true, true, false, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(57, Participant.Recipient1, Participant.Recipient1, false, true, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(58, Participant.Sender, Participant.Recipient2, false, true, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(59, Participant.Recipient2, Participant.Recipient2, false, true, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(60, Participant.Sender, Participant.Recipient1, true, true, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(61, Participant.Recipient1, Participant.Recipient1, true, true, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(62, Participant.Sender, Participant.Recipient2, true, true, true, true), new TestOutput("#", "#", "#", "#")];
        // yield return [new TestInput(63, Participant.Recipient2, Participant.Recipient2, true, true, true, true), new TestOutput("#", "#", "#", "#")];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// public class TestDataWhereOnlyR1IsFullyDecomposed : IEnumerable<object[]>
// {
//     public IEnumerator<object[]> GetEnumerator()
//     {
//         return new TestDataWithAllCases().Where(d =>
//         {
//             var input = (TestInput)d[0];
//             var output = (TestOutput)d[1];
//
//             return input.RelationshipTo == Participant.Recipient1 &&
//                    output.R1_HiddenForRecipient &&
//                    output.R1_HiddenForSender &&
//                    (!output.R2_HiddenForRecipient || output.R2_HiddenForSender);
//             // ReSharper disable once NotDisposedResourceIsReturned
//         }).GetEnumerator();
//     }
//
//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }

// public class TestDataWhereOnlyR2IsFullyDecomposed : IEnumerable<object[]>
// {
//     public IEnumerator<object[]> GetEnumerator()
//     {
//         return new TestDataWithAllCases().Where(d =>
//         {
//             var output = (TestOutput)d[1];
//
//             return
//                 output.R2_HiddenForRecipient &&
//                 output.R2_HiddenForSender &&
//                 (!output.R1_HiddenForRecipient || output.R1_HiddenForSender);
//             // ReSharper disable once NotDisposedResourceIsReturned
//         }).GetEnumerator();
//     }
//
//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }
//
// public class TestDataWhereBothAreFullyDecomposed : IEnumerable<object[]>
// {
//     public IEnumerator<object[]> GetEnumerator()
//     {
//         return new TestDataWithAllCases().Where(d =>
//         {
//             var output = (TestOutput)d[1];
//
//             return
//                 output.R1_HiddenForRecipient &&
//                 output.R1_HiddenForSender &&
//                 output.R2_HiddenForRecipient &&
//                 output.R2_HiddenForSender;
//             // ReSharper disable once NotDisposedResourceIsReturned
//         }).GetEnumerator();
//     }
//
//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }
