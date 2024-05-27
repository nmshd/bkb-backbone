import 'dart:io';

import 'package:admin_api_sdk/admin_api_sdk.dart';
import 'package:admin_api_types/admin_api_types.dart';
import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:intl/intl.dart';

class IdentityDetails extends StatefulWidget {
  final String address;

  const IdentityDetails({required this.address, super.key});

  @override
  State<IdentityDetails> createState() => _IdentityDetailsState();
}

class _IdentityDetailsState extends State<IdentityDetails> {
  Identity? _identityDetails;
  late List<TierOverview> _tiers;
  String? _selectedTier;

  late final ScrollController _scrollController;

  @override
  void initState() {
    super.initState();

    _scrollController = ScrollController();

    _reloadIdentity();
    _reloadTiers();
  }

  @override
  void dispose() {
    _scrollController.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    if (_identityDetails == null) return const Center(child: CircularProgressIndicator());

    final identityDetails = _identityDetails!;
    return Scrollbar(
      controller: _scrollController,
      child: SingleChildScrollView(
        controller: _scrollController,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            if (Platform.isMacOS || Platform.isWindows) const BackButton(),
            _IdentityDetailsCard(
              identityDetails: identityDetails,
              selectedTier: _selectedTier,
              onTierChanged: (String? newValue) {
                setState(() {
                  _selectedTier = newValue;
                });
              },
              availableTiers: _tiers,
              updateTierOfIdentity: _reloadIdentity,
            ),
          ],
        ),
      ),
    );
  }

  Future<void> _reloadIdentity() async {
    final identityDetails = await GetIt.I.get<AdminApiClient>().identities.getIdentity(widget.address);
    if (mounted) {
      setState(() {
        _identityDetails = identityDetails.data;
        _selectedTier = _identityDetails!.tierId;
      });
    }
  }

  Future<void> _reloadTiers() async {
    final tiers = await GetIt.I.get<AdminApiClient>().tiers.getTiers();
    if (mounted) {
      setState(() => _tiers = tiers.data);
    }
  }
}

class _IdentityDetailsCard extends StatelessWidget {
  final Identity identityDetails;
  final String? selectedTier;
  final ValueChanged<String?>? onTierChanged;
  final List<TierOverview> availableTiers;
  final VoidCallback? updateTierOfIdentity;

  const _IdentityDetailsCard({
    required this.identityDetails,
    required this.availableTiers,
    this.selectedTier,
    this.onTierChanged,
    this.updateTierOfIdentity,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: Card(
            child: Padding(
              padding: const EdgeInsets.all(16),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  _IdentityDetails(
                    title: 'Address',
                    value: identityDetails.address,
                  ),
                  const SizedBox(height: 32),
                  Wrap(
                    spacing: 8,
                    runSpacing: 8,
                    children: [
                      _IdentityDetails(
                        title: 'Client ID',
                        value: identityDetails.clientId,
                      ),
                      _IdentityDetails(
                        title: 'Public Key',
                        value: identityDetails.publicKey,
                      ),
                      _IdentityDetails(
                        title: 'Created at',
                        value: DateFormat('yyyy-MM-dd hh:mm:ss').format(identityDetails.createdAt),
                      ),
                      Row(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          _IdentityTierDropdown(
                            selectedTier: selectedTier,
                            identityDetails: identityDetails,
                            onTierChanged: onTierChanged,
                            availableTiers: availableTiers,
                            updateTierOfIdentity: updateTierOfIdentity,
                          ),
                        ],
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),
        ),
      ],
    );
  }
}

class _IdentityTierDropdown extends StatelessWidget {
  final String? selectedTier;
  final Identity identityDetails;
  final ValueChanged<String?>? onTierChanged;
  final List<TierOverview> availableTiers;
  final VoidCallback? updateTierOfIdentity;

  const _IdentityTierDropdown({
    required this.selectedTier,
    required this.identityDetails,
    required this.onTierChanged,
    required this.availableTiers,
    required this.updateTierOfIdentity,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          'Tier ',
          style: Theme.of(context).textTheme.bodyLarge!.copyWith(fontWeight: FontWeight.bold),
        ),
        DropdownButton<String>(
          isDense: true,
          value: selectedTier,
          onChanged: (String? newTier) {
            onTierChanged?.call(newTier);
            if (newTier != identityDetails.tierId) {
              _updateTierOfIdentity(newTier, context);
            }
          },
          items: _buildTierDropdownItems(context),
        ),
      ],
    );
  }

  List<DropdownMenuItem<String>> _buildTierDropdownItems(BuildContext context) {
    return availableTiers.where(_isTierManuallyAssignable).map((tier) {
      final isDisabled = _isTierDisabled(tier);
      return DropdownMenuItem<String>(
        value: tier.id,
        enabled: !isDisabled,
        child: Text(
          tier.name,
          style: TextStyle(
            color: isDisabled ? Theme.of(context).disabledColor : null,
            fontSize: 18,
          ),
        ),
      );
    }).toList();
  }

  bool _isTierDisabled(TierOverview tier) {
    final tiersThatCannotBeUnassigned = availableTiers.where((t) => !t.canBeManuallyAssigned);
    final identityIsInTierThatCannotBeUnassigned = tiersThatCannotBeUnassigned.any((t) => t.id == identityDetails.tierId);
    return identityIsInTierThatCannotBeUnassigned && tier.id != identityDetails.tierId;
  }

  bool _isTierManuallyAssignable(TierOverview tier) {
    return tier.canBeManuallyAssigned || tier.id == identityDetails.tierId;
  }

  Future<void> _updateTierOfIdentity(String? newTier, BuildContext context) async {
    final scaffoldMessenger = ScaffoldMessenger.of(context);

    try {
      await GetIt.I.get<AdminApiClient>().identities.updateIdentity(identityDetails.address, tierId: newTier!);

      scaffoldMessenger.showSnackBar(
        const SnackBar(
          content: Text('Identity updated successfully.'),
          duration: Duration(seconds: 3),
        ),
      );

      updateTierOfIdentity!();
    } catch (e) {
      scaffoldMessenger.showSnackBar(
        const SnackBar(
          content: Text('Failed to update identity. Please try again.'),
          duration: Duration(seconds: 3),
        ),
      );
    }
  }
}

class _IdentityDetails extends StatelessWidget {
  final String title;
  final String value;

  const _IdentityDetails({required this.title, required this.value});

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text.rich(
          TextSpan(
            children: [
              TextSpan(text: '$title ', style: Theme.of(context).textTheme.bodyLarge!.copyWith(fontWeight: FontWeight.bold)),
              TextSpan(text: value, style: Theme.of(context).textTheme.bodyLarge),
            ],
          ),
        ),
      ],
    );
  }
}
