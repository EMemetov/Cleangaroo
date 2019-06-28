CREATE TABLE [dbo].[appointment] (
    [idappointment]        NUMERIC (10) NOT NULL,
    [idserviceprice]       NUMERIC (10) NOT NULL,
    [idcustomer]           NUMERIC (10) NOT NULL,
    [cthoursrequested]     NUMERIC (3)  NULL,
    [idcleaner]            NUMERIC (10) NOT NULL,
    [cleanerrate]          VARCHAR (10) NULL,
    CONSTRAINT [appointment_pk] PRIMARY KEY CLUSTERED ([idappointment] ASC),
    CONSTRAINT [appointment_cleaner_fk] FOREIGN KEY ([idcleaner]) REFERENCES [dbo].[cleaner] ([idcleaner]),
    CONSTRAINT [appointment_customer_fk] FOREIGN KEY ([idcustomer]) REFERENCES [dbo].[customer] ([idcustomer]),
    CONSTRAINT [appointment_serviceprice_fk] FOREIGN KEY ([idserviceprice]) REFERENCES [dbo].[serviceprice] ([idserviceprice])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [appointment_idx]
    ON [dbo].[appointment]([idserviceprice] ASC);

