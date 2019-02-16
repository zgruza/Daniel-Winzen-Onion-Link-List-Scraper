# Daniel Winzen Onion Link List Crawler
This is simple Crawler for Onions & Descriptions in [onions.DanWin1210.me](https://onions.danwin1210.me/)

++ This script is easy Customizable

## Requirements
[HtmlAgalityPack](https://www.nuget.org/packages/HtmlAgilityPack/)
## Setup
```
1. Edit Database credetains in put_onion.php
2. Then run https://YourDomain.com/put_onion.php?setup
== DONE ==
```

If you want just save Onions & Descriptions to txt file just Comment
```
//WebClient put_data = new WebClient();
//string url_put = "https://YourDomain.com/put_onion.php?onion="+onion+"&des="+description;
//byte[] html = put_data.DownloadData(url_put);
//UTF8Encoding utf = new UTF8Encoding();
//string done_check = utf.GetString(html);
```
and Uncomment that part what started
``` 
file.Write(..
```