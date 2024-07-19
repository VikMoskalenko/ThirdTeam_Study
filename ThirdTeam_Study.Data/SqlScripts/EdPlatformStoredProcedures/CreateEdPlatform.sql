CREATE PROCEDURE CreateEdPlaform
	@Language varchar(8),
	@Theme int

AS
BEGIN
	INSERT INTO EdPlatform(Name, Language, Theme)
	VALUES ('HillelEdPlatform', @Language, @Theme)

END