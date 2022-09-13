


update Cards set Cards.isavailable = 1 
, Costusd = t2.price 
from (select product ,[Type] 
, min(PurchasePrice ) as price
from livecard.Temp_PrepaidForgeStocks
group by product,[Type] ) t2
where Cards.ApiName = 'PrepaidForge' 
and Cards.ApiSku = t2.product


 
-- select top 1 * from  cards -- set costusd = costusd * 1.042857
-- where isavailable = 1 and  DefaultPriceCurrency = 'eur'


--update cards set  Active = 0 
--where isavailable = 0
 