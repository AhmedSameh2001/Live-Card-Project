USE [livecardsdb]
GO

INSERT INTO [dbo].[Cards]
           ([Name]
           ,[BrandId]
           ,[CostUSD]
		   ,[AgentPercent]
		   ,[SellerPercent]
		   ,[CustomerPercent]
           ,[AddedDate]
           ,[Active]
           ,[IsDeleted]
           ,[Image]
           ,[ApiName]
           ,[ApiSku]
           ,[IsAvailable]
           ,[DefaultPriceAmount]
           ,[DefaultPriceCurrency]
           ,[FaceValueAmount]
           ,[FaceValueCurrency]
           ,[countries]
           ,[platforms]
		   ,[languages])
  (
    
SELECT        livecard.Temp_ProductAPIDetails.name, dbo.Brands.Id, 0 AS CostUSD,

10 , 12, 15 ,

 GETDATE() AS addedDate, livecard.Temp_ProductAPIDetails.active, 0 AS IsDeleted, livecard.Temp_ProductAPIDetails.imageUrl, 
                         'PrepaidForge' AS ApiName, livecard.Temp_ProductAPIDetails.sku, 0 AS IsAvailable , dbo.DefaultPrice.amount AS DefaultPriceAmount, dbo.DefaultPrice.currency AS DefaultPriceCurrency, 
                         dbo.FaceValue.amount AS FaceValueAmount, dbo.FaceValue.currency AS FaceValueCurrency, livecard.Temp_ProductAPIDetails.countries2, livecard.Temp_ProductAPIDetails.platforms2, 
                         livecard.Temp_ProductAPIDetails.languages2
FROM            dbo.Categories INNER JOIN
                         dbo.Brands ON dbo.Categories.Id = dbo.Brands.CategoryId AND dbo.Categories.Id = dbo.Brands.CategoryId INNER JOIN
                         dbo.DefaultPrice INNER JOIN
                         livecard.Temp_ProductAPIDetails ON dbo.DefaultPrice.Id = livecard.Temp_ProductAPIDetails.defaultPriceId INNER JOIN
                         dbo.FaceValue ON livecard.Temp_ProductAPIDetails.faceValueId = dbo.FaceValue.Id ON dbo.Brands.Name = livecard.Temp_ProductAPIDetails.brand AND dbo.Categories.Name = livecard.Temp_ProductAPIDetails.category2)
GO


