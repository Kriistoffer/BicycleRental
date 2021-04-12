CREATE TABLE [dbo].[Unicycle] (
    [article_number] INT          IDENTITY (600000, 1) NOT NULL,
    [frame_number]   VARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([article_number] ASC),
    FOREIGN KEY ([frame_number]) REFERENCES [dbo].[Bicycle] ([frame_number])
);

