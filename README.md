# Query OleDB monitor
A Management Pack and SCOM extenaion tool created by Uretzky Zvi for monitoring SQL queries with System Center Operations Manager.

If you use this and don't hate it, buy me a beer :-)

 Bitcoin Address: 1HPXi5M38F9zCtp1nciaGc15JdR48DrgVv
 
 Ethereum Address: 0x6a34dab1c1e655bb1fab6279204c3eb4ea840e48

## License

[License](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/LICENSE)

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
3. Import the management packs into SCOM, navigate to C:\Program Files (x86)\QueryOleDbMonitoring\ManagmentPasks
4. Run As Administrator C:\Program Files (x86)\QueryOleDbMonitoring\ManageSCOMOleDbQueryMonitor.exe
5. At first time execution fill SCOM Server.
![ConnectionServer](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/Images/Slide1.GIF)
6. Click on Add Query
![AddQuery](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/Images/Slide2.GIF)
7. Follow to wizard
  * Select DBEngine
  ![SelectDBEngine](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/Images/Slide3.GIF)
  * Write Query (Importent! make sure the query return result is a single numeric value), check connection by click on link
  ![SelectDatabase](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/Images/Slide4.GIF)
  ![query](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/Images/Slide5.GIF)
  * Define Monitor, fill a friendly query name, group name for grouping purpose, for readable alert write your error message and
  give a name for the numric value that return from query, for performance collection.
  ![monitor](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/Images/Slide6.GIF)
  * Click on Finsh
  ![Finish](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/Images/Slide7.GIF)
 8. Click on Refersh button
  ![Refersh](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/Images/Slide8.GIF)
 9. Open SCOM console, see new folder
  ![Folder](https://github.com/uretskyzvi/Monitor-Applications-Using-SQL-Queries/blob/master/Images/Slide11.GIF) 
 10. Enjoy!
  
  
