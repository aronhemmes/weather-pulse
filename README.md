# weather-pulse
CPaaS software test - CM intern hand out assignment. A weather update messaging API


## Setup

Create a local database with the following table:
```sql
CREATE TABLE [dbo].[User] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Phone]     VARCHAR (20)     NOT NULL,
    [Location]  VARCHAR (50)     NOT NULL,
    [Longitude] DECIMAL (9, 6)   NOT NULL,
    [Latitude]  DECIMAL (9, 6)   NOT NULL,
    [Timezone]  VARCHAR (50)     NOT NULL,
    UNIQUE NONCLUSTERED ([Phone] ASC)
);
```

Add ApiKey and database connection string to a secrets file like this:
```json
{
  "ConnectionStrings:UserDB": "",
  "ApiKey": ""
}
```

Run the application!