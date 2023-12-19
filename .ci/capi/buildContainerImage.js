#!/usr/bin/env node

import { $ } from "zx";
import { getRequiredEnvVar } from "../lib.js";

const tag = getRequiredEnvVar("TAG");

const platforms = process.env.PLATFORMS ?? "linux/amd64,linux/arm64";
const push = process.env.PUSH === "1" ? "--push" : "--load";

await $`docker buildx build --file ./ConsumerApi/Dockerfile --tag ghcr.io/nmshd/backbone-consumer-api:${tag} --provenance=true --sbom=true  --platform ${platforms} ${push} .`;
