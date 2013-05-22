autohaus
========

An open source demo site for Sitecore 7

Requirements:

1.	Exact build of 7.0 rev. 130424.

2.	Sitecore MVC disabled.
	To do so, rename the extension of the Sitecore.Mvc* config files under App_Config/Include.
	
How to Install to site:

1.  Get the latest .update file from /download and install it with /sitecore/admin/UpdateInstallationWizard.aspx.

    The package will deploy tons of items in post-install, so it could take a while (5-10 minutes to finish).
	Afterwards, it will kick off index rebuild of the master indexes.
	No manual steps are required after the install.

How to build locally

Requirements: TDS.

After you get the sources:

1. Drop the following DLLs here from your Sitecore 7.0 rev. 130424 distributive.

	HtmlAgilityPack.dll
	Lucene.Net.Contrib.Analyzers.dll
	Lucene.Net.dll
	Sitecore.Buckets.Client.dll
	Sitecore.Buckets.dll
	Sitecore.Client.dll
	Sitecore.ContentSearch.dll
	Sitecore.ContentSearch.Linq.dll
	Sitecore.ContentSearch.Linq.Lucene.dll
	Sitecore.ContentSearch.LuceneProvider.dll
	Sitecore.Kernel.dll
	Sitecore.Logging.dll
	Sitecore.Update.dll
	Sitecore.Zip.dll

2. Tweak TDS settings for Debug configuration like the webroot path, etc.

3. Hit Rebuild All.






