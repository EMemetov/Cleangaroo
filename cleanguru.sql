-- Generated by Oracle SQL Developer Data Modeler 19.1.0.081.0911
--   at:        2019-06-26 10:00:58 EDT
--   site:      SQL Server 2012
--   type:      SQL Server 2012



CREATE TABLE address (
    idaddress     NUMERIC(10) NOT NULL,
    idcustomer    NUMERIC(10) NOT NULL,
    address       VARCHAR(50),
    addressunit   VARCHAR(15),
    postalcode    VARCHAR(6),
    city          VARCHAR(25),
    province      VARCHAR(2)
)

    


CREATE unique nonclustered index address_idx ON address ( idcustomer )

ALTER TABLE Address ADD constraint address_pk PRIMARY KEY CLUSTERED (IdAddress)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE appointment (
    idappointment          NUMERIC(10) NOT NULL,
    idserviceprice         NUMERIC(10) NOT NULL,
    idcustomer             NUMERIC(10) NOT NULL,
    ctdaterequestservice   datetime,
    cthoursrequested       NUMERIC(3),
    clockin                datetime,
    idcleaner              NUMERIC(10) NOT NULL,
    clockout               datetime,
    cleanerrate            VARCHAR(10)
)


    


CREATE unique nonclustered index appointment_idx ON appointment ( idserviceprice ) 

ALTER TABLE Appointment ADD constraint appointment_pk PRIMARY KEY CLUSTERED (IdAppointment)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE appointmentpayment (
    idappointmentpayment   NUMERIC(10) NOT NULL,
    clhoursworked          NUMERIC(2),
    cthourscontracted      NUMERIC(2),
    paidtocleaner          CHAR(1) DEFAULT 'N',
    paidbycustomer         CHAR(1) DEFAULT 'N',
    amountpaidtocleaner    NUMERIC(10, 2),
    amountpaidbycustomer   NUMERIC(10, 2),
    idappointment          NUMERIC(10) NOT NULL
)

 


ALTER TABLE AppointmentPayment 
    ADD 
    CHECK ( paidToCleaner IN ('N', 'Y') ) 



ALTER TABLE AppointmentPayment 
    ADD 
    CHECK ( paidByCustomer IN ('N', 'Y') ) 


    
CREATE unique nonclustered index appointmentpayment_idx ON appointmentpayment ( idappointment ) 

ALTER TABLE AppointmentPayment ADD constraint appointmentpayment_pk PRIMARY KEY CLUSTERED (IdAppointmentPayment)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE cleaner (
    idcleaner       NUMERIC(10) NOT NULL,
    fcleanername    VARCHAR(50) NOT NULL,
    mcleanername    VARCHAR(50),
    lcleanername    VARCHAR(50) NOT NULL,
    claddress       VARCHAR(60),
    claddressunit   VARCHAR(15),
    clpostalcode    VARCHAR(6),
    clcity          VARCHAR(25),
    clprovince      VARCHAR(2),
    clphone1        VARCHAR(14),
    clphone2        VARCHAR(14),
    clsincnumber    VARCHAR(9),
    username        VARCHAR(40) NOT NULL
)

 

CREATE unique nonclustered index cleaner_idx ON cleaner ( username ) 

ALTER TABLE Cleaner ADD constraint cleaner_pk PRIMARY KEY CLUSTERED (IdCleaner)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE customer (
    idcustomer      NUMERIC(10) NOT NULL,
    fcustomername   VARCHAR(50) NOT NULL,
    mcustomername   VARCHAR(50),
    lcustomername   VARCHAR(50) NOT NULL,
    ctphone1        VARCHAR(14),
    ctphone2        VARCHAR(14),
    ctemail         VARCHAR(40),
    username        VARCHAR(40) NOT NULL
)

 

    


CREATE unique nonclustered index customer_idx ON customer ( username ) 

ALTER TABLE Customer ADD constraint customer_pk PRIMARY KEY CLUSTERED (IdCustomer)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE customersubscription (
    idsubscription   NUMERIC(10) NOT NULL,
    subscription     CHAR(1),
    periodicity      VARCHAR(10),
    finishdate       datetime,
    idcustomer       NUMERIC(10) NOT NULL
)



ALTER TABLE CustomerSubscription ADD constraint customersubscription_pk PRIMARY KEY CLUSTERED (IdSubscription)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE schedulecleaner (
    idschedulecleaner   NUMERIC(10) NOT NULL,
    dayweek             VARCHAR(10) NOT NULL,
    initialtime         time NOT NULL,
    finishtime          time NOT NULL,
    idcleaner           NUMERIC(10) NOT NULL
)


ALTER TABLE ScheduleCleaner ADD constraint schedulecleaner_pk PRIMARY KEY CLUSTERED (IdScheduleCleaner)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE serviceprice (
    idserviceprice       NUMERIC(10) NOT NULL,
    ctamounthour         NUMERIC(8, 2) NOT NULL,
    clamounthour         NUMERIC(8, 2) NOT NULL,
    servicepricestatus   CHAR(1) NOT NULL
)



ALTER TABLE ServicePrice ADD constraint serviceprice_pk PRIMARY KEY CLUSTERED (IdServicePrice)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

CREATE TABLE userlogin (
    username   VARCHAR(40) NOT NULL,
    pin        VARCHAR(8) NOT NULL,
    role       VARCHAR(15) NOT NULL
)

 


ALTER TABLE userlogin add check(role IN(
    'CLEANER', 'CUSTOMER', 'MANAGER'
)) 

ALTER TABLE UserLogin ADD constraint userlogin_pk PRIMARY KEY CLUSTERED (Username)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON ) 

ALTER TABLE Address
    ADD CONSTRAINT address_customer_fk FOREIGN KEY ( idcustomer )
        REFERENCES customer ( idcustomer )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE Appointment
    ADD CONSTRAINT appointment_cleaner_fk FOREIGN KEY ( idcleaner )
        REFERENCES cleaner ( idcleaner )
ON DELETE NO ACTION 
    ON UPDATE no action 

ALTER TABLE Appointment
    ADD CONSTRAINT appointment_customer_fk FOREIGN KEY ( idcustomer )
        REFERENCES customer ( idcustomer )
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
    ADD CONSTRAINT customersubscription_customer_fk FOREIGN KEY ( idcustomer )
        REFERENCES customer ( idcustomer )
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
-- ALTER TABLE                             21
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
