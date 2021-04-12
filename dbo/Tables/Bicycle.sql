CREATE TABLE [dbo].[Bicycle] (
    [frame_number]     VARCHAR (25) NOT NULL,
    [bicycle_type]     VARCHAR (25) NULL,
    [bicycle_category] VARCHAR (25) NULL,
    [recommended_user] VARCHAR (12) NULL,
    [make]             VARCHAR (25) NULL,
    [model]            VARCHAR (25) NULL,
    [color]            VARCHAR (15) NULL,
    [frame_size]       VARCHAR (8)  NULL,
    [wheel_size]       VARCHAR (6)  NULL,
    [gears]            TINYINT      NULL,
    [brake_back]       VARCHAR (12) NULL,
    [brake_front]      VARCHAR (12) NULL,
    [price]            INT          NULL,
    PRIMARY KEY CLUSTERED ([frame_number] ASC)
);

