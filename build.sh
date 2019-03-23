#!/usr/bin/env bash

#exit if any command fails
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then
  rm -R $artifactsFolder
fi

#dotnet build ./DynamicReadingService.UnitTest/DynamicReadingService.UnitTest.csproj

#dotnet test --no-build ./DynamicReadingService.UnitTest/DynamicReadingService.UnitTest.csproj


revision=${TRAVIS_JOB_ID:=1}
revision=$(printf "%04d" $revision) 

dotnet publish ./DynamicReadingService.API/DynamicReadingService.API.csproj -c Release -o ../artifacts/API --version-suffix=$revision