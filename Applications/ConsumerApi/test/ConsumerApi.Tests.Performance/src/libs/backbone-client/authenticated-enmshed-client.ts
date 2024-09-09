import { CreateChallengeResponse, JwtResponse } from "../../models";
import { BaseEnmeshedClient } from "./base-enmshed-client";
import { apiVersion } from "./constants";
import { FluentClient } from "./fluent-client";

export class AuthenticatedEnmeshedClient extends BaseEnmeshedClient {
    public readonly username: string;
    private readonly password: string;

    private token_expires_at = new Date();
    private access_token = "";

    private readonly tokenExchangeClient!: FluentClient;

    public constructor(username: string, password: string) {
        super();

        this.username = username;
        this.password = password;
        this.tokenExchangeClient = new FluentClient(this.httpxClient);
    }

    private tokenIsStillValid(): boolean {
        return +this.token_expires_at - 1000 > +new Date();
    }

    private exchangeToken() {
        const payload = {
            client_id: this.clientId,
            client_secret: this.clientSecret,
            grant_type: "password",
            username: this.username,
            password: this.password
        };
        const response = this.tokenExchangeClient.setEndpoint("connect/token").setHeaders({ "Content-Type": "application/x-www-form-urlencoded" }).post<JwtResponse>(payload, null);

        this.access_token = `${response.token_type} ${response.access_token}`;
        this.token_expires_at = new Date(+new Date() + response.expires_in * 1000);
    }

    private getAccessToken(): string {
        if (!this.tokenIsStillValid()) {
            this.exchangeToken();
        }

        return this.access_token;
    }

    public getChallenge(): CreateChallengeResponse {
        return this.client.setEndpoint(`api/${apiVersion}/Challenges`).asJson().authenticate(this.getAccessToken()).post<CreateChallengeResponse>(null);
    }
}
