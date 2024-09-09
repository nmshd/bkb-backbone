import { check } from "k6";
import { SharedArray } from "k6/data";
import { Options } from "k6/options";
import { AuthenticatedEnmeshedClient } from "../libs/backbone-client/authenticated-enmshed-client";
import { DataRepresentationForEnmeshedPerformanceTestsLoads } from "../libs/data-loader/models";
import { LoadDataRepresentationForEnmeshedPerformanceTests } from "../libs/file-utils";

export const options: Options = {
    scenarios: {
        constantRequestRate: {
            executor: "constant-arrival-rate",
            rate: 1,
            timeUnit: "5m",
            duration: "60m",
            preAllocatedVUs: 1
        }
    }
};

const snapshot = (__ENV.snapshot as string | undefined) ?? "light";

const pools = LoadDataRepresentationForEnmeshedPerformanceTests(snapshot, [DataRepresentationForEnmeshedPerformanceTestsLoads.Identities]).ofTypes("a", "c").pools;

const testIdentities = new SharedArray("testIdentities", function () {
    return pools.flatMap((p) => p.identities);
});

let identityIterator = 0;

export default function (): void {
    const currentIdentity = testIdentities[identityIterator++];

    const username = currentIdentity.devices[0].username;
    const password = currentIdentity.devices[0].password;
    const client = new AuthenticatedEnmeshedClient(username, password);

    const createChallengeResult = client.getChallenge();

    console.log(
        `[${identityIterator}]\tCurrent device id: ${currentIdentity.devices[0].deviceId}. Challenge created with device Id: ${createChallengeResult.createdByDevice}. Match = ${currentIdentity.devices[0].deviceId === createChallengeResult.createdByDevice}.\nClient username: ${client.username}, function username: ${username}. Match = ${client.username === username}.`
    );
    check(createChallengeResult, {
        "challenge contains correct device": (r) => r.createdByDevice === currentIdentity.devices[0].deviceId,
        "challenge contains correct address": (r) => r.createdBy === currentIdentity.address,
        "challenge id is not empty": (r) => r.id !== ""
    });
}
