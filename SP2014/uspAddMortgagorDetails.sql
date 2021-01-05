USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspAddMortgagorDetails]    Script Date: 02/10/2015 12:04:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Jaheda Meman>
-- Create date: <10/13/14,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[uspAddMortgagorDetails] 
    -- Add the parameters for the stored procedure here
    --First two parameters we add for the edit add mortgagor using grid. When you go serach , click edit int the grid , it brings you on Add mortgagor page then we can save the record .
    @MortgagorInformationInputID int,
    @Edit int,
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
   --- @UserID varchar(20),
   --- @CreateDate smalldatetime,
    
    @MortgagorInformationID int OUTPUT
   
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements. 
   -- SET NOCOUNT ON;
    --- This is to check if record is availble .if yes, it will go to mortgagor information table then it does update the record otherwise it will insert new record
    IF (@Edit=1)
    BEGIN
    UPDATE MortgagorInformation SET   EstateOf=@EstateOf,
                                      Prefix=@Prefix,
                                      FirstName=@FirstName,
                                      MiddleInitial=@MiddleInitial,
                                      Lastname=@Lastname,
                                      Suffix=@Suffix,
                                      Alias=@Alias,
                                      RaceID=@RaceID,
                                      Hispanic=@Hispanic,
                                      Email=@Email,
                                      Gender=@Gender,
                                      Co_Prefix=@Co_Prefix,
                                      Co_FirstName=@Co_FirstName,
                                      Co_MiddleInitial=@Co_MiddleInitial,
                                      Co_LastName=@Co_LastName,
                                      Co_Suffix=@Co_Suffix,
                                      Co_Alias=@Co_Alias,
                                      Co_BorrowerPhone=@Co_BorrowerPhone,
                                      PrimaryPhone=@PrimaryPhone,
                                      CellPhone=@CellPhone,
                                      City=@City,
                                      ZipCode=@ZipCode,
                                      State=@State,
                                      CensusTract=@CensusTract
                                     -- UserID=@UserID, 
                                    --CreateDate=@CreateDate
                                    
                                      
     WHERE MortgagorInformationID = @MortgagorInformationInputID                                   
     SET @MortgagorInformationID = @MortgagorInformationInputID;
     END
     ELSE IF (@Edit=0)
     BEGIN
    
   IF(Exists(SELECT lastname,Address_1,ZipCode
   FROM MortgagorInformation
   WHERE  Upper(Lastname)=Upper(@Lastname) and  Upper(Address_1)=Upper(@Address_1) and ZipCode=@ZipCode))
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
                                      CensusTract,
                                     -- UserID,
                                    CreateDate 
                                    )
                                     
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
           @CensusTract
           ,getdate()
          -- @UserID,
          -- @CreateDate
          )
           
           SET @MortgagorInformationID=SCOPE_IDENTITY()

       END
       END
       RETURN  @MortgagorInformationID
       END
GO

