# Query OleDB monitor
A Management Pack and SCOM extenaion tool created by Uretzky Zvi for monitoring SQL queries with System Center Operations Manager.

## Features
* Easy tool to create and delete queries.
* Dedicated Views in SCOM Console.
* Performance data collection.
* Monitor using consecutive samples condition and scheduler filter.
* A group instance for several queries.

# Quick Start - Usage
Please always test new management packs in a test environment before importing to production!

## Requirements
* SCOM 2012 R2 (earlier versions are untested)
* Microsoft SQL Management Packs.
* SCOM Admin rights (only Administrators can import management packs)
## Quick Start - Install
1. Download QueryOleDbMonitorSetup.msi
2. Run As Administrator the msi file.
3. Import the management packs into SCOM, navigate to %ProgramFiles%\QueryOleDbMonitoring\ManagmentPasks
4. Run As Administrator %ProgramFiles%\QueryOleDbMonitoring\ManageSCOMOleDbQueryMonitor.exe
5. At first time execution fill SCOM Server.
6. Click on Add Query
7. Follow to wizard
