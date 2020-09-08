# mysegments
## About
This project leverages the Strava APIs to provide a user with a convenient way to see their own top ten results for each segment. The default sort will be by ranking and then drill down to segmenets that you hold that top ten ranking. 

The plan is to ignore ties and rank you according to time and if others are tied, show how many others are tied with that time.  

The plan is to ultimately let the user know when they have changes to their rankings, increasing, movements down the list, loss of top ten, etc. 

This project is not affiliated with Strava, but simply uses their published APIs and requires that the users of this web applicaiton authenticate with and consent using their Strava login credentials.

## Roadmap

## December 2019

 Have basic top ten results showing by rank.. incldding a table that shows how many results per ranking and the abililty to drill down. The results hope to also show how many times you've tied you current highest ranking and the ability to view a history of your rides that remain in the top ten rank for each segment that you current hold a top ten ranking. For example, you may have ridden a segment several times at 3rd overall, but are currently ranked 2nd overall. 

## 2020 and beyond...
In future it would be good to show top ten filtered by age and weight, so no longer 'overall' but by age and/or weight. 

Strava does not currently provide a history view of top 10s - only your KOMs.   And they rank oddly.. in that some bizarre algorithm to arbitratlily miminize the number of ties for ranking. This site will strive to not do that nonsense. Instead, you will be the official holder of lets say 2nd place if you have held that time the longest, but you will still be ranked 2nd overall if you are not the oldest. There will be a special designation for when you hold the oldest tied time for a given ranking. For the KOM, the crown will go to the holder of the fasted time that achieve it first.  The others will be ranked with a no. 1 ranking but not a crown. 
