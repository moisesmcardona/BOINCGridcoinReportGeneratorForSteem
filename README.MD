# Gridcoin Report Generator for Steem

This is the software that generates the report to the @dailygrcstats Steem account. The software downloads the user file from the BOINC project servers and then opens then and searches for users who are in the Gridcoin team. It then checks if the user has already been added to the MySQL database and if it is not there, the user gets added to the report and database.

You need to create 2 files:

**MySQLConfig.txt**

File structure is as follows:
```
server=server IP or host
username=your username
password=your password
database=the name of the database
```

**account.txt**
```
account=steem account
key=private posting key
```