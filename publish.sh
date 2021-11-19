#!/bin/bash
set -e

dotnet.exe build --configuration Release
dotnet.exe pack --configuration Release
