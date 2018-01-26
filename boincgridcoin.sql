CREATE DATABASE  IF NOT EXISTS `boincgridcoin` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `boincgridcoin`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Database: boincgridcoin
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `amicablenumbers`
--

DROP TABLE IF EXISTS `amicablenumbers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `amicablenumbers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7612 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `asteroidsathome`
--

DROP TABLE IF EXISTS `asteroidsathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `asteroidsathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=382873 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `citizensciencegrid`
--

DROP TABLE IF EXISTS `citizensciencegrid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `citizensciencegrid` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=236172 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `collatzconjecture`
--

DROP TABLE IF EXISTS `collatzconjecture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `collatzconjecture` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1584395 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `cosmologyathome`
--

DROP TABLE IF EXISTS `cosmologyathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cosmologyathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1496414 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ddathome`
--

DROP TABLE IF EXISTS `ddathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ddathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=216557 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `einsteinathome`
--

DROP TABLE IF EXISTS `einsteinathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `einsteinathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=986042 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `enigma`
--

DROP TABLE IF EXISTS `enigma`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `enigma` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=158697 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `gpugrid`
--

DROP TABLE IF EXISTS `gpugrid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gpugrid` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=521026 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `leidenclassical`
--

DROP TABLE IF EXISTS `leidenclassical`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `leidenclassical` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3208782 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `lhcathomeclassic`
--

DROP TABLE IF EXISTS `lhcathomeclassic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lhcathomeclassic` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=563368 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `milkywayathome`
--

DROP TABLE IF EXISTS `milkywayathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `milkywayathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1316604 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `moowrap`
--

DROP TABLE IF EXISTS `moowrap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `moowrap` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=262749 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `nfsathome`
--

DROP TABLE IF EXISTS `nfsathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nfsathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=366129 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `numberfieldsathome`
--

DROP TABLE IF EXISTS `numberfieldsathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `numberfieldsathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=81761 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `odlk1`
--

DROP TABLE IF EXISTS `odlk1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `odlk1` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7612 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `primegrid`
--

DROP TABLE IF EXISTS `primegrid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `primegrid` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=971489 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `rosettaathome`
--

DROP TABLE IF EXISTS `rosettaathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rosettaathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1978132 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sdg`
--

DROP TABLE IF EXISTS `sdg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sdg` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=882867 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `setiathome`
--

DROP TABLE IF EXISTS `setiathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `setiathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10654996 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `sourcefinder`
--

DROP TABLE IF EXISTS `sourcefinder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sourcefinder` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4638 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `srbase`
--

DROP TABLE IF EXISTS `srbase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `srbase` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1654 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tngrid`
--

DROP TABLE IF EXISTS `tngrid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tngrid` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1867 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tsnp`
--

DROP TABLE IF EXISTS `tsnp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tsnp` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=491989 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `universeathome`
--

DROP TABLE IF EXISTS `universeathome`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `universeathome` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=45134 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `vgtu`
--

DROP TABLE IF EXISTS `vgtu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vgtu` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=82618 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `worldcommunitygrid`
--

DROP TABLE IF EXISTS `worldcommunitygrid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `worldcommunitygrid` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1061597 DEFAULT CHARSET=utf8 COMMENT='Table that hosts the credits per gridcoin user';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `yafu`
--

DROP TABLE IF EXISTS `yafu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `yafu` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=76599 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `yoyo`
--

DROP TABLE IF EXISTS `yoyo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `yoyo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `totalcredits` varchar(255) DEFAULT NULL,
  `yesterday` varchar(255) DEFAULT NULL,
  `average` varchar(255) DEFAULT NULL,
  `cpid` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=303232 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping events for database 'boincgridcoin'
--

--
-- Dumping routines for database 'boincgridcoin'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-25 18:35:24
