CREATE TABLE [dbo].[Electric_bicycle] (
    [article_number]          INT          IDENTITY (500000, 1) NOT NULL,
    [frame_number]            VARCHAR (25) NULL,
    [battery_capacity]        VARCHAR (15) NULL,
    [battery_avg_charge_time] VARCHAR (15) NULL,
    [battery_avg_distance]    VARCHAR (15) NULL,
    [motor_power]             VARCHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([article_number] ASC),
    FOREIGN KEY ([frame_number]) REFERENCES [dbo].[Bicycle] ([frame_number])
);

