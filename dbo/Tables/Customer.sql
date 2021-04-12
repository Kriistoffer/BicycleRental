CREATE TABLE [dbo].[Customer] (
    [customerID]             INT          IDENTITY (1, 1) NOT NULL,
    [social_security_number] CHAR (12)    NOT NULL,
    [email]                  VARCHAR (50) NULL,
    [user_password]          VARCHAR (40) NULL,
    [firstName]              VARCHAR (20) NULL,
    [lastName]               VARCHAR (20) NULL,
    [adress]                 VARCHAR (25) NULL,
    [zip_code]               CHAR (6)     NULL,
    [account_created]        DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([social_security_number] ASC),
    UNIQUE NONCLUSTERED ([customerID] ASC),
    UNIQUE NONCLUSTERED ([email] ASC)
);

