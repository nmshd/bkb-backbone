namespace Backbone.Modules.Devices.Application.Infrastructure.PushNotifications.DeletionProcess;

[NotificationText(Title = "A deletion process has been cancelled", Body = "One of your identity's deletion processes was cancelled by the support team.")]
public record DeletionProcessCancelledBySupportNotification(int DaysUntilDeletion);
