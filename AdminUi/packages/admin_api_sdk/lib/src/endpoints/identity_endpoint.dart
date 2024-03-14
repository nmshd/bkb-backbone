import 'package:admin_api_types/admin_api_types.dart';

import '../builders/builders.dart';
import '../types/types.dart';
import 'endpoint.dart';

class IdentitiesEndpoint extends Endpoint {
  IdentitiesEndpoint(super._dio);

  Future<ApiResponse<Identity>> getIdentity(
    String address,
  ) =>
      get(
        '/api/v1/Identities/$address',
        transformer: Identity.fromJson,
      );

  Future<ApiResponse<void>> updateIdentity(
    String address, {
    required String tierId,
  }) =>
      put(
        '/api/v1/Identities/$address',
        data: {
          'tierId': tierId,
        },
        transformer: (e) {},
      );

  Future<ApiResponse<List<IdentityOverview>>> getIdentities({
    IdentityOverviewFilter? filter,
    int pageNumber = 0,
    int pageSize = 10,
  }) {
    final queryParameters = <String, String>{
      r'$top': '$pageSize',
      r'$skip': '${pageNumber * pageSize}',
      r'$count': 'true',
      r'$expand': 'Tier',
    };

    if (filter != null) {
      queryParameters[r'$filter'] = ODataFilterBuilder().buildOdataFilter(filter);
    }

    return getOData(
      '/odata/Identities',
      query: queryParameters,
      transformer: (e) => (e as List).map(IdentityOverview.fromJson).toList(),
    );
  }
}
