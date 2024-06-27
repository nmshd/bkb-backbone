import 'package:admin_api_sdk/admin_api_sdk.dart';
import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:intl/intl.dart';
import 'package:multi_dropdown/multiselect_dropdown.dart';

import '../../constants.dart';
import '../../extensions.dart';
import '../filters/filters.dart';

class IdentitiesFilter extends StatefulWidget {
  final Future<void> Function({IdentityOverviewFilter? filter}) onFilterChanged;
  final String? fixedTierId;

  const IdentitiesFilter({
    required this.onFilterChanged,
    this.fixedTierId,
    super.key,
  });

  @override
  State<IdentitiesFilter> createState() => _IdentitiesFilterState();
}

class _IdentitiesFilterState extends State<IdentitiesFilter> {
  IdentityOverviewFilter _filter = IdentityOverviewFilter();

  late MultiSelectController<String> _tierController;
  late MultiSelectController<String> _clientController;

  @override
  void initState() {
    super.initState();

    _tierController = MultiSelectController();
    _clientController = MultiSelectController();

    if (widget.fixedTierId != null) {
      _filter = _filter.copyWith(tiers: Optional([widget.fixedTierId!]));
    }

    _loadTiers();
    _loadClients();
  }

  @override
  void dispose() {
    _tierController.dispose();
    _clientController.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: Padding(
        padding: const EdgeInsets.all(8),
        child: Row(
          mainAxisSize: MainAxisSize.min,
          children: [
            InputField(
              label: context.l10n.address,
              onEnteredText: (String enteredText) {
                _filter = _filter.copyWith(address: enteredText.isEmpty ? const Optional.absent() : Optional(enteredText));
                widget.onFilterChanged(filter: _filter);
              },
            ),
            if (widget.fixedTierId == null) ...[
              Gaps.w16,
              MultiSelectFilter(
                label: context.l10n.tiers,
                searchLabel: context.l10n.searchEntities(context.l10n.tiers),
                controller: _tierController,
                onOptionSelected: (List<ValueItem<String>> selectedOptions) {
                  final selectedTiers = selectedOptions.map((item) => item.value!).toList();
                  _filter = _filter.copyWith(tiers: selectedTiers.isEmpty ? const Optional.absent() : Optional(selectedTiers));
                  widget.onFilterChanged(filter: _filter);
                },
              ),
            ],
            Gaps.w16,
            MultiSelectFilter(
              label: context.l10n.clients,
              searchLabel: context.l10n.searchEntities(context.l10n.clients),
              controller: _clientController,
              onOptionSelected: (List<ValueItem<String>> selectedOptions) {
                final selectedClients = selectedOptions.map((item) => item.value!).toList();
                _filter = _filter.copyWith(clients: selectedClients.isEmpty ? const Optional.absent() : Optional(selectedClients));
                widget.onFilterChanged(filter: _filter);
              },
            ),
            Gaps.w16,
            NumberFilter(
              label: context.l10n.numberOfEntities(context.l10n.devices),
              onNumberSelected: (FilterOperator operator, String enteredValue) {
                final numberOfDevices = FilterOperatorValue(operator, enteredValue);
                _filter = _filter.copyWith(numberOfDevices: numberOfDevices.value.isEmpty ? const Optional.absent() : Optional(numberOfDevices));
                widget.onFilterChanged(filter: _filter);
              },
            ),
            Gaps.w16,
            DateFilter(
              label: context.l10n.createdAt,
              onFilterSelected: (FilterOperator operator, DateTime? selectedDate) {
                final createdAt = FilterOperatorValue(operator, selectedDate != null ? DateFormat('yyyy-MM-dd').format(selectedDate) : '');
                _filter = _filter.copyWith(createdAt: createdAt.value.isEmpty ? const Optional.absent() : Optional(createdAt));
                widget.onFilterChanged(filter: _filter);
              },
            ),
            Gaps.w16,
            DateFilter(
              label: context.l10n.last_login_at,
              onFilterSelected: (FilterOperator operator, DateTime? selectedDate) {
                final lastLoginAt = FilterOperatorValue(operator, selectedDate != null ? DateFormat('yyyy-MM-dd').format(selectedDate) : '');
                _filter = _filter.copyWith(lastLoginAt: lastLoginAt.value.isEmpty ? const Optional.absent() : Optional(lastLoginAt));
                widget.onFilterChanged(filter: _filter);
              },
            ),
            Gaps.w16,
            NumberFilter(
              label: context.l10n.entityVersion(context.l10n.datawallet),
              onNumberSelected: (FilterOperator operator, String enteredValue) {
                final datawalletVersion = FilterOperatorValue(operator, enteredValue);
                _filter =
                    _filter.copyWith(datawalletVersion: datawalletVersion.value.isEmpty ? const Optional.absent() : Optional(datawalletVersion));
                widget.onFilterChanged(filter: _filter);
              },
            ),
            Gaps.w16,
            NumberFilter(
              label: context.l10n.entityVersion(context.l10n.identity),
              onNumberSelected: (FilterOperator operator, String enteredValue) {
                final identityVersion = FilterOperatorValue(operator, enteredValue);
                _filter = _filter.copyWith(identityVersion: identityVersion.value.isEmpty ? const Optional.absent() : Optional(identityVersion));
                widget.onFilterChanged(filter: _filter);
              },
            ),
          ],
        ),
      ),
    );
  }

  Future<void> _loadTiers() async {
    final response = await GetIt.I.get<AdminApiClient>().tiers.getTiers();
    final tierItems = response.data.map((tier) => ValueItem(label: tier.name, value: tier.id)).toList();
    _tierController.setOptions(tierItems);
  }

  Future<void> _loadClients() async {
    final response = await GetIt.I.get<AdminApiClient>().clients.getClients();
    final clientItems = response.data.map((client) => ValueItem(label: client.displayName, value: client.clientId)).toList();
    _clientController.setOptions(clientItems);
  }
}
