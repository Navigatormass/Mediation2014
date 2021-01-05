USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[spAddMortgagorDetails]    Script Date: 02/10/2015 10:06:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddMortgagorDetails] 
    -- Add the parameters for the stored procedure here
    @EstateOf tinyint,
    @Prefix varchar(4),
    @FirstName varchar(35),
    @MiddleInitial varchar(4),
    @LastName varchar(35),
    @Suffix varchar(4),
    @Alias varchar(80),
    @RaceID smallint,
    @Hispanic tinyint,
    @Email varchar(60),
    @Gender char(1),
    @Co_Prefix varchar(4),
    @Co_FirstName varchar(35),
    @Co_MiddleInitial varchar(4),
    @Co_LastName varchar(35),
    @Co_Suffix varchar(4),
    @Co_Alias varchar(80),
    @Co_BorrowerPhone varchar(14),
    @PrimaryPhone varchar(14),
    @CellPhone varchar(14),
    @Address_1 varchar(40),
    @Address_2 varchar(40),
    @City varchar(28),
    @ZipCode char(5),
    @State char(2),
    @CensusTract varchar(7),
    @MortgagorInformationID int OUTPUT

    
    
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;
   IF(Exists(SELECT lastname,Address_1,ZipCode from MortgagorInformation where  Upper(lastname)=Upper(@lastname) and  Upper(Address_1)=Upper(@Address_1) and ZipCode=@ZipCode))
   BEGIN
    SET @MortgagorInformationID=-1;
    
   END
   ELSE
   BEGIN
    -- Insert statements for procedure here
   INSERT INTO MortgagorInformation (
                                      EstateOf,
                                      Prefix,
                                      FirstName,
                                      MiddleInitial,
                                      LastName,
                                      Suffix,
                                      Alias,
                                      RaceID,
                                      Hispanic,
                                      Email,
                                      Gender,
                                      Co_Prefix,
                                      Co_FirstName,
                                      Co_MiddleInitial,
                                      Co_LastName,
                                      Co_Suffix ,
                                      Co_Alias,
                                      Co_BorrowerPhone,
                                      PrimaryPhone,
                                      CellPhone,
                                      Address_1,
                                      Address_2,
                                      City,
                                      ZipCode,
                                      State,
                                      CensusTract)
                                     
    VALUES(
           @EstateOf,
           @Prefix,
           @FirstName,
           @MiddleInitial,
           @LastName,
           @Suffix,
           @Alias,
           @RaceID,
           @Hispanic,
           @Email,
           @Gender,
           @Co_Prefix,
           @Co_FirstName,
           @Co_MiddleInitial,
           @Co_LastName,
           @Co_Suffix ,
           @Co_Alias,
           @Co_BorrowerPhone,
           @PrimaryPhone,
           @CellPhone,
           @Address_1,
           @Address_2,
           @City,
           @ZipCode,
           @State,
           @CensusTract)
            SET @MortgagorInformationID=SCOPE_IDENTITY()

      
       END
      RETURN  @MortgagorInformationID
      END
GO

