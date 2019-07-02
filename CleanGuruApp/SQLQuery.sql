﻿CREATE TABLE Appointment 
    ( idAppointment INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     idServicePrice INTEGER NOT NULL , 
     idCustomer INTEGER NOT NULL , 
     ctDateRequestService DATETIME , 
     ctHoursRequested NUMERIC (3) , 
     clockIn DATETIME , 
     idCleaner INTEGER NOT NULL , 
     clockOut DATETIME , 
     cleanerRate VARCHAR (10) , 
     startTime DATETIME , 
     isSubscription BIT 
    )


    


CREATE unique nonclustered index appointment_idx ON appointment ( idAppointment )


ALTER TABLE Appointment ADD constraint appointment_pk PRIMARY KEY CLUSTERED (idAppointment)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE AppointmentPayment 
    ( idAppointmentPayment INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     clHoursWorked NUMERIC (2) , 
     ctHoursContracted NUMERIC (2) , 
     paidToCleaner CHAR (1) DEFAULT 'N' , 
     paidByCustomer CHAR (1) DEFAULT 'N' , 
     amountPaidToCleaner NUMERIC (10,2) , 
     amountPaidByCustomer NUMERIC (10,2) , 
     idAppointment INTEGER NOT NULL 
    )



ALTER TABLE AppointmentPayment 
    ADD 
    CHECK ( paidToCleaner IN ('N', 'Y') ) 


ALTER TABLE AppointmentPayment 
    ADD 
    CHECK ( paidByCustomer IN ('N', 'Y') ) 

    


CREATE unique nonclustered index appointmentpayment_idx ON AppointmentPayment ( idAppointmentPayment ) 

ALTER TABLE AppointmentPayment ADD constraint appointmentpayment_pk PRIMARY KEY CLUSTERED (idAppointmentPayment)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE Cleaner 
    ( idCleaner INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     fCleanerName VARCHAR (50) NOT NULL , 
     mCleanerName VARCHAR (50) , 
     lCleanerName VARCHAR (50) NOT NULL , 
     clAddress VARCHAR (60) , 
     clAddressUnit VARCHAR (15) , 
     clPostalCode VARCHAR (6) , 
     clCity VARCHAR (25) , 
     clProvince VARCHAR (2) , 
     clPhone1 VARCHAR (14) , 
     clPhone2 VARCHAR (14) , 
     clSinNumber VARCHAR (9) , 
     username VARCHAR (40) NOT NULL 
    )
 

    


CREATE unique nonclustered index cleaner_idx ON cleaner ( idCleaner) 

ALTER TABLE Cleaner ADD constraint cleaner_pk PRIMARY KEY CLUSTERED (idCleaner)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE Customer 
    ( idCustomer INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     fCustomerName VARCHAR (50) NOT NULL , 
     mCustomerName VARCHAR (50) , 
     lCustomerName VARCHAR (50) NOT NULL , 
     ctPhone1 VARCHAR (14) , 
     ctPhone2 VARCHAR (14) , 
     ctEmail VARCHAR (40) , 
     username VARCHAR (40) NOT NULL 
    )

    


CREATE unique nonclustered index customer_idx ON customer ( idCustomer ) 

ALTER TABLE Customer ADD constraint customer_pk PRIMARY KEY CLUSTERED (idCustomer)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE CustomerAddress 
    ( idCustAddress INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     idCustomer INTEGER NOT NULL , 
     address VARCHAR (50) , 
     addressUnit VARCHAR (15) , 
     postalCode VARCHAR (6) , 
     city VARCHAR (25) , 
     province VARCHAR (2) 
    )

    


CREATE unique nonclustered index address_idx ON customeraddress ( idCustAddress ) 

ALTER TABLE CustomerAddress ADD constraint address_pk PRIMARY KEY CLUSTERED (idCustAddress)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE CustomerSubscription 
    ( idSubscription INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     periodicity INTEGER , 
     finishDate DATETIME , 
     idAppointment INTEGER NOT NULL ) 

ALTER TABLE CustomerSubscription ADD constraint customersubscription_pk PRIMARY KEY CLUSTERED (idSubscription)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE ScheduleCleaner 
    ( idScheduleCleaner INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
     dayWeek VARCHAR (10) NOT NULL , 
     initialTime TIME NOT NULL , 
     finishTime TIME NOT NULL , 
     idCleaner INTEGER NOT NULL ) 

ALTER TABLE ScheduleCleaner ADD constraint schedulecleaner_pk PRIMARY KEY CLUSTERED (idScheduleCleaner)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE ServicePrice 
    ( idServicePrice INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
      servicePriceDescr VARCHAR(20) NOT NULL,
     ctAmountHour NUMERIC (8,2) NOT NULL , 
     clAmountHour NUMERIC (8,2) NOT NULL , 
     servicePriceStatus CHAR (1) NOT NULL DEFAULT 'A' 
    )
 


ALTER TABLE serviceprice add check(servicepricestatus IN(
    'A', 'I'
)) 

ALTER TABLE ServicePrice ADD constraint serviceprice_pk PRIMARY KEY CLUSTERED (idServicePrice)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE userlogin (
    userName   VARCHAR(40) NOT NULL,
    pin        VARCHAR(8) NOT NULL,
    role       VARCHAR(15) NOT NULL
)




ALTER TABLE userlogin add check(role IN(
    'CLEANER', 'CUSTOMER', 'MANAGER'
)) 

ALTER TABLE UserLogin ADD constraint userlogin_pk PRIMARY KEY CLUSTERED (userName)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

ALTER TABLE CustomerAddress
    ADD CONSTRAINT address_customer_fk FOREIGN KEY ( idCustomer )
        REFERENCES customer ( idcustomer )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE Appointment
    ADD CONSTRAINT appointment_cleaner_fk FOREIGN KEY ( idCleaner )
        REFERENCES cleaner ( idCleaner )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE Appointment
    ADD CONSTRAINT appointment_customer_fk FOREIGN KEY ( idCustomer )
        REFERENCES customer ( idCustomer )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE Appointment
    ADD CONSTRAINT appointment_serviceprice_fk FOREIGN KEY ( idserviceprice )
        REFERENCES serviceprice ( idserviceprice )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE AppointmentPayment
    ADD CONSTRAINT appointmentpayment_appointment_fk FOREIGN KEY ( idappointment )
        REFERENCES appointment ( idappointment )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE Cleaner
    ADD CONSTRAINT cleaner_userlogin_fk FOREIGN KEY ( username )
        REFERENCES userlogin ( username )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE Customer
    ADD CONSTRAINT customer_userlogin_fk FOREIGN KEY ( username )
        REFERENCES userlogin ( username )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE CustomerSubscription
    ADD CONSTRAINT customersubscription_appointment_fk FOREIGN KEY ( idappointment )
        REFERENCES appointment ( idappointment )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE ScheduleCleaner
    ADD CONSTRAINT schedulecleaner_cleaner_fk FOREIGN KEY ( idcleaner )
        REFERENCES cleaner ( idcleaner )
ON DELETE NO ACTION 
    ON UPDATE no action 



-- Oracle SQL Developer Data Modeler Summary Report: 
-- 
-- CREATE TABLE                             9
-- CREATE INDEX                             5
-- ALTER TABLE                             22
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0