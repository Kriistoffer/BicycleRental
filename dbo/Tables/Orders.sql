CREATE TABLE [dbo].[Orders] (
    [orderID]                INT          IDENTITY (1, 1) NOT NULL,
    [social_security_number] CHAR (12)    NULL,
    [frame_number]           VARCHAR (25) NULL,
    [rent_start]             DATE         NULL,
    [rent_stop]              DATE         NULL,
    [total_price]            INT          NULL,
    [payment_method]         VARCHAR (15) NULL,
    [order_made]             DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([orderID] ASC),
    FOREIGN KEY ([frame_number]) REFERENCES [dbo].[Bicycle] ([frame_number]),
    FOREIGN KEY ([social_security_number]) REFERENCES [dbo].[Customer] ([social_security_number])
);

