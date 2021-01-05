USE [Mediation2014]
GO

/****** Object:  StoredProcedure [dbo].[uspAddMediationContacts]    Script Date: 02/10/2015 12:03:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	<Author,,Jaheda Meman>
-- Create date: <10/12/14,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[uspAddMediationContacts] 
    -- Add the parameters for the stored procedure here
    --First two parameters we add for the edit add mortgagor using grid. When you go serach , click edit int the grid , it brings you on Add mortgagor page then we can save the record .
    @ContactID int,
    @Name varchar(225),
    @ContactName varchar(70),
    @ContactTitle varchar(60),
    @Address_1 varchar(40),
    @Address_2  varchar(40),
    @City varchar(28),
    @State varchar(2),
    @ZipCode varchar(5),
    @Email varchar(80),
    @OfficePhone varchar(10),
    @Extension varchar(5),
    @FaxNumber varchar(10),
    @AltPhoneNumber varchar(10),
    @AltExtension varchar(5),
    @Edit int,
    @ID int,
    @outputContactID int OUTPUT
   
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements. 
   -- SET NOCOUNT ON;
    --- This is to check if record is availble .if yes, it will go to mortgagor information table then it does update the record otherwise it will insert new record
    IF (@Edit=1)
    BEGIN
        IF(@ID=1)
			BEGIN
			UPDATE LenderContact set LenderName=@Name,ContactName =@ContactName,ContactTitle=@ContactTitle ,Address_1=@Address_1,Address_2=@Address_2,Email=@Email, City=@City,State=@State,ZipCode=@ZipCode,OfficePhone=@OfficePhone,Extension=@Extension,FaxNumber=@FaxNumber,AltPhoneNumber=@AltPhoneNumber,AltExtension=@AltExtension where LenderContactID=@ContactID
			END
        ELSE IF(@ID=2)   
			BEGIN
			UPDATE  AttorneyContact set LawFirmName=@Name,AttorneyName =@ContactName ,Address_1=@Address_1,Address_2=@Address_2,Email=@Email,City=@City,State=@State,ZipCode=@ZipCode,OfficePhone=@OfficePhone,Extension=@Extension,FaxNumber=@FaxNumber,AltPhoneNumber=@AltPhoneNumber,AltExtension=@AltExtension where AttorneyContactID=@ContactID
			END  
		ELSE IF(@ID=3)   
			BEGIN
			UPDATE  CertificateLetterContact set AgencyName=@Name,ContactName =@ContactName,ContactTitle=@ContactTitle ,Address_1=@Address_1,Address_2=@Address_2,Email=@Email,City=@City,State=@State,ZipCode=@ZipCode,OfficePhone=@OfficePhone,Extension=@Extension,FaxNumber=@FaxNumber,AltPhoneNumber=@AltPhoneNumber,AltExtension=@AltExtension where CertificateLetterContactID=@ContactID
			END  
		ELSE IF(@ID=4)   
			BEGIN
			UPDATE  MediationContact set AgencyName=@Name,MediationContactName =@ContactName,ContactTitle=@ContactTitle ,Address_1=@Address_1,Address_2=@Address_2,Email=@Email,City=@City,State=@State,ZipCode=@ZipCode,OfficePhone=@OfficePhone,Extension=@Extension,FaxNumber=@FaxNumber,AltPhoneNumber=@AltPhoneNumber,AltExtension=@AltExtension where MediationContactID=@ContactID
			END  
		 ELSE IF(@ID=5)   
			BEGIN
			UPDATE  ServicerContact set AgencyName=@Name,ServicerName =@ContactName ,Address_1=@Address_1,Address_2=@Address_2,Email=@Email,City=@City,State=@State,ZipCode=@ZipCode,OfficePhone=@OfficePhone,Extension=@Extension,FaxNumber=@FaxNumber,AltPhoneNumber=@AltPhoneNumber,AltExtension=@AltExtension where ServicerContactID=@ContactID
			END                    
     SET @outputContactID = @ContactID;
     END
     ELSE IF (@Edit=0)
     BEGIN
    
 
    -- Insert statements for procedure here
    
    IF(@ID=1)
			BEGIN
			INSERT INTO LenderContact (LenderName,ContactName,ContactTitle,Address_1,Address_2,AltExtension,AltPhoneNumber,City,Email,Extension,FaxNumber,OfficePhone,State,ZipCode) values(@Name,@ContactName,@ContactTitle,@Address_1,@Address_2,@AltExtension,@AltPhoneNumber,@City,@Email,@Extension,@FaxNumber,@OfficePhone,@State,@ZipCode)
			END
   ELSE IF(@ID=2)
			BEGIN
			INSERT INTO AttorneyContact(LawFirmName,AttorneyName,Address_1,Address_2,AltExtension,AltPhoneNumber,City,Email,Extension,FaxNumber,OfficePhone,State,ZipCode) values(@Name,@ContactName,@Address_1,@Address_2,@AltExtension,@AltPhoneNumber,@City,@Email,@Extension,@FaxNumber,@OfficePhone,@State,@ZipCode)
			END
   ELSE IF(@ID=3)
			BEGIN
			INSERT INTO CertificateLetterContact(AgencyName,ContactName,ContactTitle, Address_1,Address_2,AltExtension,AltPhoneNumber,City,Email,Extension,FaxNumber,OfficePhone,State,ZipCode) values(@Name,@ContactName,@ContactTitle, @Address_1,@Address_2,@AltExtension,@AltPhoneNumber,@City,@Email,@Extension,@FaxNumber,@OfficePhone,@State,@ZipCode)
			END  
			
   ELSE IF(@ID=4)
			BEGIN
			INSERT INTO MediationContact(AgencyName,MediationContactName,ContactTitle, Address_1,Address_2,AltExtension,AltPhoneNumber,City,Email,Extension,FaxNumber,OfficePhone,State,ZipCode) values(@Name,@ContactName,@ContactTitle, @Address_1,@Address_2,@AltExtension,@AltPhoneNumber,@City,@Email,@Extension,@FaxNumber,@OfficePhone,@State,@ZipCode)
			END   
			
  ELSE IF(@ID=5)
			BEGIN
			INSERT INTO ServicerContact(AgencyName,ServicerName, Address_1,Address_2,AltExtension,AltPhoneNumber,City,Email,Extension,FaxNumber,OfficePhone,State,ZipCode) values(@Name,@ContactName, @Address_1,@Address_2,@AltExtension,@AltPhoneNumber,@City,@Email,@Extension,@FaxNumber,@OfficePhone,@State,@ZipCode)
			END             
            SET @outputContactID=SCOPE_IDENTITY()

       END

       RETURN  @outputContactID
       END

GO

