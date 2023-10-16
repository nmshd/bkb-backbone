import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpResponseEnvelope } from "src/app/utils/http-response-envelope";
import { environment } from "src/environments/environment";
import { Quota } from "../quotas-service/quotas.service";
import { ODataResponse } from "src/app/utils/odata-response";
import ODataFilterBuilder from "odata-filter-builder";
import { NumberFilter } from "src/app/utils/number-filter";
import { DateFilter } from "src/app/utils/date-filter";
import { NGXLogger } from "ngx-logger";

@Injectable({
    providedIn: "root"
})
export class IdentityService {
    private readonly apiUrl: string;
    private readonly odataUrl: string;

    public constructor(
        private readonly http: HttpClient,
        private readonly logger: NGXLogger
    ) {
        this.apiUrl = `${environment.apiUrl}/Identities`;
        this.odataUrl = `${environment.odataUrl}/Identities`;
    }

    public getIdentities(filter: IdentityOverviewFilter, pageNumber: number, pageSize: number): Observable<ODataResponse<IdentityOverview[]>> {
        const paginationFilter = `$top=${pageSize}&$skip=${pageNumber}`;
        return this.http.get<ODataResponse<IdentityOverview[]>>(`${this.odataUrl}${this.buildODataFilter(filter, paginationFilter)}`);
    }

    public getIdentityByAddress(address: string): Observable<HttpResponseEnvelope<Identity>> {
        return this.http.get<HttpResponseEnvelope<Identity>>(`${this.apiUrl}/${address}`);
    }

    private buildODataFilter(filter: IdentityOverviewFilter, paginationFilter: string): string {
        const odataFilter = ODataFilterBuilder();

        if (filter.address !== undefined && filter.address !== "") odataFilter.contains("address", filter.address);

        if (filter.tiers !== undefined && filter.tiers.length > 0) {
            filter.tiers.forEach((tier) => {
                odataFilter.eq("tierId", tier);
            });
        }

        if (filter.clients !== undefined && filter.clients.length > 0) {
            filter.clients.forEach((client) => {
                odataFilter.eq("createdWithClient", client);
            });
        }

        if (filter.createdAt.operator !== undefined && filter.createdAt.value !== undefined) {
            switch (filter.createdAt.operator) {
                case ">":
                    odataFilter.gt("createdAt", filter.createdAt.value);
                    break;
                case "<":
                    odataFilter.lt("createdAt", filter.createdAt.value);
                    break;
                case "=":
                    odataFilter.eq("createdAt", filter.createdAt.value);
                    break;
                case "<=":
                    odataFilter.le("createdAt", filter.createdAt.value);
                    break;
                case ">=":
                    odataFilter.ge("createdAt", filter.createdAt.value);
                    break;
                default:
                    this.logger.error(`Invalid createdAt filter operator: ${filter.createdAt.operator}`);
                    break;
            }
        }

        if (filter.lastLoginAt.operator !== undefined && filter.lastLoginAt.value !== undefined) {
            switch (filter.lastLoginAt.operator) {
                case ">":
                    odataFilter.gt("lastLoginAt", filter.lastLoginAt.value);
                    break;
                case "<":
                    odataFilter.lt("lastLoginAt", filter.lastLoginAt.value);
                    break;
                case "=":
                    odataFilter.eq("lastLoginAt", filter.lastLoginAt.value);
                    break;
                case "<=":
                    odataFilter.le("lastLoginAt", filter.lastLoginAt.value);
                    break;
                case ">=":
                    odataFilter.ge("lastLoginAt", filter.lastLoginAt.value);
                    break;
                default:
                    this.logger.error(`Invalid lastLoginAt filter operator: ${filter.lastLoginAt.operator}`);
                    break;
            }
        }

        if (filter.numberOfDevices.operator !== undefined && filter.numberOfDevices.value !== undefined) {
            switch (filter.numberOfDevices.operator) {
                case ">":
                    odataFilter.gt("numberOfDevices", filter.numberOfDevices.value);
                    break;
                case "<":
                    odataFilter.lt("numberOfDevices", filter.numberOfDevices.value);
                    break;
                case "=":
                    odataFilter.eq("numberOfDevices", filter.numberOfDevices.value);
                    break;
                case "<=":
                    odataFilter.le("numberOfDevices", filter.numberOfDevices.value);
                    break;
                case ">=":
                    odataFilter.ge("numberOfDevices", filter.numberOfDevices.value);
                    break;
                default:
                    this.logger.error(`Invalid numberOfDevices filter operator: ${filter.numberOfDevices.operator}`);
                    break;
            }
        }

        if (filter.datawalletVersion.operator !== undefined && filter.datawalletVersion.value !== undefined) {
            switch (filter.datawalletVersion.operator) {
                case ">":
                    odataFilter.gt("datawalletVersion", filter.datawalletVersion.value);
                    break;
                case "<":
                    odataFilter.lt("datawalletVersion", filter.datawalletVersion.value);
                    break;
                case "=":
                    odataFilter.eq("datawalletVersion", filter.datawalletVersion.value);
                    break;
                case "<=":
                    odataFilter.le("datawalletVersion", filter.datawalletVersion.value);
                    break;
                case ">=":
                    odataFilter.ge("datawalletVersion", filter.datawalletVersion.value);
                    break;
                default:
                    this.logger.error(`Invalid datawalletVersion filter operator: ${filter.datawalletVersion.operator}`);
                    break;
            }
        }

        if (filter.identityVersion.operator !== undefined && filter.identityVersion.value !== undefined) {
            switch (filter.identityVersion.operator) {
                case ">":
                    odataFilter.gt("identityVersion", filter.identityVersion.value);
                    break;
                case "<":
                    odataFilter.lt("identityVersion", filter.identityVersion.value);
                    break;
                case "=":
                    odataFilter.eq("identityVersion", filter.identityVersion.value);
                    break;
                case "<=":
                    odataFilter.le("identityVersion", filter.identityVersion.value);
                    break;
                case ">=":
                    odataFilter.ge("identityVersion", filter.identityVersion.value);
                    break;
                default:
                    this.logger.error(`Invalid identityVersion filter operator: ${filter.identityVersion.operator}`);
                    break;
            }
        }

        let filterParameter = "";
        if (odataFilter.toString() !== "") filterParameter = `?$filter=${odataFilter.toString()}`;
        if (filterParameter === "") {
            filterParameter += `?${paginationFilter}`;
        } else {
            filterParameter += `&${paginationFilter}`;
        }

        return filterParameter;
    }

    public updateIdentity(identity: Identity, params: UpdateTierRequest): Observable<HttpResponseEnvelope<Identity>> {
        return this.http.put<HttpResponseEnvelope<Identity>>(`${this.apiUrl}/${identity.address}`, params);
    }
}

export interface Identity {
    address: string;
    clientId: string;
    publicKey: string;
    createdAt: Date;
    identityVersion: string;
    quotas: Quota[];
    devices: Device[];
    tierId: string;
}

export interface Device {
    id: string;
    username: string;
    createdAt: Date;
    lastLogin: LastLoginInformation;
    createdByDevice: string;
}

export interface LastLoginInformation {
    time?: Date;
}

export interface IdentityOverview {
    address: string;
    createdAt: Date;
    lastLoginAt: Date;
    createdWithClient: string;
    datawalletVersion: string;
    tierName: string;
    tierId: string;
    identityVersion: string;
    numberOfDevices: number;
}

export interface IdentityOverviewFilter {
    address?: string;
    tiers?: string[];
    clients?: string[];
    numberOfDevices: NumberFilter;
    createdAt: DateFilter;
    lastLoginAt: DateFilter;
    datawalletVersion: NumberFilter;
    identityVersion: NumberFilter;
}

export interface UpdateTierRequest {
    tierId: string;
}
