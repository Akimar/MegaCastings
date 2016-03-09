<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">	
	<xsl:template match="/">
		<?DOCTYPE html?>
		<html>
			<head>
			    <meta charset="utf-8"/>
				<meta http-equiv="X-UA-Compatible" content="IE=edge"/>
				<meta name="viewport" content="width=device-width, initial-scale=1"/>  
				<link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
				<title>
					<xsl:apply-templates select="/rss/channel/title"/>
				</title>
			</head>
			<body>
				<nav class="navbar navbar-default">
				  <div class="container-fluid">
					<div class="navbar-header">
					  <a class="navbar-brand" href="#"><xsl:apply-templates select="/rss/channel/title"/></a>
					</div>
					<div>
					  <ul class="nav navbar-nav">
						<li class="active"><a href="#">MegaCasting</a></li>
						<li><a href="#">Page 1</a></li>
						<li><a href="#">Page 2</a></li>
						<li><a href="#">Page 3</a></li>
					  </ul>
					</div>
				  </div>
				</nav>
				
				<h1 class="text-primary"><xsl:apply-templates select="/rss/channel/description"/></h1>

				<div class="container">
				    <div class="row">
						<xsl:apply-templates select="/rss/channel//offre"/>
					</div>
				</div>

				<footer>
					<i class="glyphicon glyphicon-user"></i>
					By Merlin Loison - Massamba Sène
					<i class="glyphicon glyphicon-heart"></i>
				</footer>
				<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
				<script src="js/jquery-1.11.3.min.js"></script>
				<!-- Include all compiled plugins (below), or include individual files as needed -->
				<script src="js/bootstrap.min.js"></script>
			</body>
		</html>
	</xsl:template>
	
	<xsl:template match="channel/title">
		<xsl:value-of select="."/>
	</xsl:template>
	
	<xsl:template match="channel/description">
		<xsl:value-of select="."/>
	</xsl:template>
	
	<xsl:template match="offre">
		<xsl:variable name="lien" select="link">
		</xsl:variable>
		
		<xsl:variable name="date" select="pubDate">
		</xsl:variable>
		
			<xsl:variable name="image" select="enclosure/@url">
			</xsl:variable>
	
		<div class="col-md-4 panel-group" padding="2px">
			<div class="panel panel-primary">
				<div class="panel-heading"> 
					<h2><xsl:value-of select="title"/></h2>
				</div>
				<br/><br/>
				<div class="panel-body">
					<!-- <a href="{$lien}" target="_blank">
						<img class="img-responsive" src="{$image}" alt ="test"/>
					</a>-->
					<p><xsl:value-of select="description"/>		
					<br/>
					<a data-toggle="tooltip" data-placement="top" title="{$date}" href="{$lien}" target="_blank"> 
						...lire la suite
					</a>
					</p>
				</div>
			</div>
		</div>
	</xsl:template>
	
	
	
</xsl:stylesheet>

