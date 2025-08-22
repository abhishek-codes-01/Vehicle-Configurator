-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: project1
-- ------------------------------------------------------
-- Server version	8.0.40

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alternate_component_master`
--

DROP TABLE IF EXISTS `alternate_component_master`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alternate_component_master` (
  `alt_id` int NOT NULL AUTO_INCREMENT,
  `delta_price` double NOT NULL,
  `alt_comp_id` int DEFAULT NULL,
  `comp_id` int DEFAULT NULL,
  `model_id` int DEFAULT NULL,
  PRIMARY KEY (`alt_id`),
  KEY `FKm4cheb7najst01d9osf4d2ndg` (`alt_comp_id`),
  KEY `FK4lvi9he1pavviuy8rkf0o2r32` (`comp_id`),
  KEY `FKi45u4ycb7uf5ucb23rdrsuuri` (`model_id`),
  CONSTRAINT `FK4lvi9he1pavviuy8rkf0o2r32` FOREIGN KEY (`comp_id`) REFERENCES `component` (`comp_id`),
  CONSTRAINT `FKi45u4ycb7uf5ucb23rdrsuuri` FOREIGN KEY (`model_id`) REFERENCES `model` (`model_id`),
  CONSTRAINT `FKm4cheb7najst01d9osf4d2ndg` FOREIGN KEY (`alt_comp_id`) REFERENCES `component` (`comp_id`)
) ENGINE=InnoDB AUTO_INCREMENT=181 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alternate_component_master`
--

LOCK TABLES `alternate_component_master` WRITE;
/*!40000 ALTER TABLE `alternate_component_master` DISABLE KEYS */;
INSERT INTO `alternate_component_master` VALUES (1,0,7,7,1),(2,-15,28,7,1),(3,20,29,7,1),(4,0,12,12,1),(5,-10,30,12,1),(6,50,31,12,1),(7,0,16,16,1),(8,-30,32,16,1),(9,80,33,16,1),(10,0,21,21,1),(11,-50,34,21,1),(12,60,35,21,1),(13,0,23,23,1),(14,-20,36,23,1),(15,80,37,23,1),(16,0,27,27,1),(17,-40,38,27,1),(18,30,39,27,1),(19,0,7,7,2),(20,-15,28,7,2),(21,20,29,7,2),(22,0,12,12,2),(23,-10,30,12,2),(24,50,31,12,2),(25,0,16,16,2),(26,-30,32,16,2),(27,80,33,16,2),(28,0,21,21,2),(29,-50,34,21,2),(30,60,35,21,2),(31,0,23,23,2),(32,-20,36,23,2),(33,80,37,23,2),(34,0,27,27,2),(35,-40,38,27,2),(36,30,39,27,2),(37,0,7,7,3),(38,-15,28,7,3),(39,20,29,7,3),(40,0,12,12,3),(41,-10,30,12,3),(42,50,31,12,3),(43,0,16,16,3),(44,-30,32,16,3),(45,80,33,16,3),(46,0,21,21,3),(47,-50,34,21,3),(48,60,35,21,3),(49,0,23,23,3),(50,-20,36,23,3),(51,80,37,23,3),(52,0,27,27,3),(53,-40,38,27,3),(54,30,39,27,3),(55,0,7,7,4),(56,-15,28,7,4),(57,20,29,7,4),(58,0,12,12,4),(59,-10,30,12,4),(60,50,31,12,4),(61,0,16,16,4),(62,-30,32,16,4),(63,80,33,16,4),(64,0,21,21,4),(65,-50,34,21,4),(66,60,35,21,4),(67,0,23,23,4),(68,-20,36,23,4),(69,80,37,23,4),(70,0,27,27,4),(71,-40,38,27,4),(72,30,39,27,4),(73,0,7,7,5),(74,-15,28,7,5),(75,20,29,7,5),(76,0,12,12,5),(77,-10,30,12,5),(78,50,31,12,5),(79,0,16,16,5),(80,-30,32,16,5),(81,80,33,16,5),(82,0,21,21,5),(83,-50,34,21,5),(84,60,35,21,5),(85,0,23,23,5),(86,-20,36,23,5),(87,80,37,23,5),(88,0,27,27,5),(89,-40,38,27,5),(90,30,39,27,5),(91,0,7,7,6),(92,-15,28,7,6),(93,20,29,7,6),(94,0,12,12,6),(95,-10,30,12,6),(96,50,31,12,6),(97,0,16,16,6),(98,-30,32,16,6),(99,80,33,16,6),(100,0,21,21,6),(101,-50,34,21,6),(102,60,35,21,6),(103,0,23,23,6),(104,-20,36,23,6),(105,80,37,23,6),(106,0,27,27,6),(107,-40,38,27,6),(108,30,39,27,6),(109,0,7,7,7),(110,-15,28,7,7),(111,20,29,7,7),(112,0,12,12,7),(113,-10,30,12,7),(114,50,31,12,7),(115,0,16,16,7),(116,-30,32,16,7),(117,80,33,16,7),(118,0,21,21,7),(119,-50,34,21,7),(120,60,35,21,7),(121,0,23,23,7),(122,-20,36,23,7),(123,80,37,23,7),(124,0,27,27,7),(125,-40,38,27,7),(126,30,39,27,7),(127,0,7,7,8),(128,-15,28,7,8),(129,20,29,7,8),(130,0,12,12,8),(131,-10,30,12,8),(132,50,31,12,8),(133,0,16,16,8),(134,-30,32,16,8),(135,80,33,16,8),(136,0,21,21,8),(137,-50,34,21,8),(138,60,35,21,8),(139,0,23,23,8),(140,-20,36,23,8),(141,80,37,23,8),(142,0,27,27,8),(143,-40,38,27,8),(144,30,39,27,8),(145,0,7,7,9),(146,-15,28,7,9),(147,20,29,7,9),(148,0,12,12,9),(149,-10,30,12,9),(150,50,31,12,9),(151,0,16,16,9),(152,-30,32,16,9),(153,80,33,16,9),(154,0,21,21,9),(155,-50,34,21,9),(156,60,35,21,9),(157,0,23,23,9),(158,-20,36,23,9),(159,80,37,23,9),(160,0,27,27,9),(161,-40,38,27,9),(162,30,39,27,9),(163,0,7,7,10),(164,-15,28,7,10),(165,20,29,7,10),(166,0,12,12,10),(167,-10,30,12,10),(168,50,31,12,10),(169,0,16,16,10),(170,-30,32,16,10),(171,80,33,16,10),(172,0,21,21,10),(173,-50,34,21,10),(174,60,35,21,10),(175,0,23,23,10),(176,-20,36,23,10),(177,80,37,23,10),(178,0,27,27,10),(179,-40,38,27,10),(180,30,39,27,10);
/*!40000 ALTER TABLE `alternate_component_master` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `component`
--

DROP TABLE IF EXISTS `component`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `component` (
  `comp_id` int NOT NULL AUTO_INCREMENT,
  `comp_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`comp_id`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `component`
--

LOCK TABLES `component` WRITE;
/*!40000 ALTER TABLE `component` DISABLE KEYS */;
INSERT INTO `component` VALUES (1,'177-hp, 2.4-liter, 16-Valve, DOHC, i-VTEC®, 4-Cylinder Engine'),(2,'5-Speed Manual Transmission'),(3,'Double Wishbone Front Suspension'),(4,'Independent Multi-Link Rear Suspension'),(5,'Front and Rear Stabilizer Bars'),(6,'Variable Gear Ratio (VGR) Power-Assisted Rack-and-Pinion Steering'),(7,'3-Point rear Seat Belts'),(8,'Front 3-Point Seat Belts with Automatic Tensioning System'),(9,'Dual-Stage, Dual Threshold Front Airbags (SRS)'),(10,'Advanced Compatibility Engineering? (ACE?) body structure'),(11,'Four-wheel Disc Brakes'),(12,'Anti-Lock Braking System (ABS)'),(13,'Lower Anchors and Tethers for Children (LATCH)'),(14,'Child-Seat Tether Anchor (Rear-Center)'),(15,'Emergency Trunk Opener'),(16,'Blue star Air Conditioning with Air Filtration System'),(17,'Power Windows with Auto-Up/Down Driver\'s and Front pax\'s windows'),(18,'Power Door Locks'),(19,'Cruise Control'),(20,'Driver\'s Seat With 4Way Power Adjustment'),(21,'JBC 160-Watt AM/FM/CD Audio System with 2 speakers'),(22,'Tilt and Telescopic Steering Column'),(23,'16-inch Wheels'),(24,'Flat Blade Windshield Wipers'),(25,'Security System'),(26,'White body colour'),(27,'Black colour bumper'),(28,'150-hp, 1.8-liter, 4-Cylinder Turbo Engine'),(29,'200-hp, 2.5-liter, V6 Hybrid Engine'),(30,'MacPherson Strut Front Suspension'),(31,'Multi-Link Independent Rear Suspension'),(32,'Auto Dimming Rearview Mirror'),(33,'Wireless Charging Pad'),(34,'Electric Power-Assisted Steering'),(35,'Hydraulic Rack-and-Pinion Steering'),(36,'Rear Seat Belts with Load Limiters'),(37,'Front Pretensioner Seat Belts'),(38,'ISOFIX Child Seat Mounts'),(39,'Child Safety Rear Door Locks'),(40,'Rear Child Restraint System'),(41,'Adaptive Cruise Control'),(42,'Smart Cruise with Lane Assist'),(43,'Dynamic Radar Cruise Control'),(44,'Side Impact Door Beams'),(45,'Crumple Zones Front and Rear'),(46,'Reinforced Passenger Cell'),(47,'Immobilizer System'),(48,'Remote Keyless Entry'),(49,'Anti-Theft Alarm System'),(50,'Rain Sensing Wipers'),(51,'Rear Window Wiper'),(52,'Heated Windshield Wipers'),(53,'18-inch Alloy Wheels'),(54,'17-inch Steel Wheels'),(55,'19-inch Dual-Tone Alloy Wheels'),(56,'8-Speaker Premium Audio System'),(57,'Surround Sound Audio with Subwoofer'),(58,'Bluetooth Enabled Infotainment System'),(59,'Ventilated Front Seats'),(60,'Heated Rear Seats'),(61,'Ergonomic Adjustable Seats'),(62,'Dual-Zone Automatic Climate Control'),(63,'Rear AC Vents with Air Purifier'),(64,'Smart Climate Sensing AC System'),(65,'Power Sliding Side Doors'),(66,'Soft Close Door Mechanism'),(67,'Frameless Door Design'),(68,'Tinted Glass Windows'),(69,'Rain-Sensing Auto Windows'),(70,'UV-Filtering Power Windows'),(71,'6-Speed Automatic Transmission'),(72,'CVT with Sport Mode'),(73,'7-Speed Dual-Clutch Transmission'),(74,'Power Liftgate Trunk'),(75,'Hands-Free Trunk Opener'),(76,'Smart Trunk with Sensor Opening'),(77,'Electronic Brakeforce Distribution (EBD)'),(78,'Brake Assist System (BAS)'),(79,'Regenerative Braking System'),(80,'Side Curtain Airbags'),(81,'Knee Airbags for Driver and Passenger'),(82,'Rear Seat Airbags'),(83,'Metallic Silver Body Colour'),(84,'Matte Black Finish'),(85,'Cherry Red Glossy Finish');
/*!40000 ALTER TABLE `component` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice_detail`
--

DROP TABLE IF EXISTS `invoice_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice_detail` (
  `inv_dtl_id` int NOT NULL AUTO_INCREMENT,
  `comp_id` int DEFAULT NULL,
  `inv_id` int DEFAULT NULL,
  PRIMARY KEY (`inv_dtl_id`),
  KEY `FK5s9brexbb6mpqno76lu4r0kq4` (`comp_id`),
  KEY `FKh4pomcctpse293ksqx8bcgni1` (`inv_id`),
  CONSTRAINT `FK5s9brexbb6mpqno76lu4r0kq4` FOREIGN KEY (`comp_id`) REFERENCES `component` (`comp_id`),
  CONSTRAINT `FKh4pomcctpse293ksqx8bcgni1` FOREIGN KEY (`inv_id`) REFERENCES `invoiceheader` (`inv_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice_detail`
--

LOCK TABLES `invoice_detail` WRITE;
/*!40000 ALTER TABLE `invoice_detail` DISABLE KEYS */;
INSERT INTO `invoice_detail` VALUES (1,16,25),(2,34,25),(3,35,28),(4,23,28),(5,27,28),(6,16,29),(7,34,29),(8,36,29),(9,27,29),(10,12,30),(11,32,30),(12,34,30),(13,29,31),(14,12,31),(15,23,31),(16,38,31),(17,12,35),(18,16,35),(19,37,35),(20,27,35),(21,38,36);
/*!40000 ALTER TABLE `invoice_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice_header`
--

DROP TABLE IF EXISTS `invoice_header`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice_header` (
  `inv_id` int NOT NULL AUTO_INCREMENT,
  `amt` double NOT NULL,
  `customer_detail` varchar(255) DEFAULT NULL,
  `inv_date` date DEFAULT NULL,
  `tax` double NOT NULL,
  `total_amt` double NOT NULL,
  `model_id` int DEFAULT NULL,
  PRIMARY KEY (`inv_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice_header`
--

LOCK TABLES `invoice_header` WRITE;
/*!40000 ALTER TABLE `invoice_header` DISABLE KEYS */;
INSERT INTO `invoice_header` VALUES (1,100,'Online Customer','2025-08-15',32.4,1699.2,NULL);
/*!40000 ALTER TABLE `invoice_header` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoiceheader`
--

DROP TABLE IF EXISTS `invoiceheader`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoiceheader` (
  `inv_id` int NOT NULL AUTO_INCREMENT,
  `amt` double NOT NULL,
  `customer_detail` varchar(255) DEFAULT NULL,
  `inv_date` date DEFAULT NULL,
  `tax` double NOT NULL,
  `total_amt` double NOT NULL,
  `model_id` int DEFAULT NULL,
  PRIMARY KEY (`inv_id`),
  KEY `FKessgqd4wqflf6us1qk01f3fi1` (`model_id`),
  CONSTRAINT `FKessgqd4wqflf6us1qk01f3fi1` FOREIGN KEY (`model_id`) REFERENCES `model` (`model_id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoiceheader`
--

LOCK TABLES `invoiceheader` WRITE;
/*!40000 ALTER TABLE `invoiceheader` DISABLE KEYS */;
INSERT INTO `invoiceheader` VALUES (1,100,'Online Customer','2025-08-07',23.4,1227.2,NULL),(2,100,'Online Customer','2025-08-07',18,944,NULL),(3,100,'Online Customer','2025-08-07',36,1888,NULL),(4,100,'Online Customer','2025-08-07',34.2,1793.6,NULL),(5,100,'Online Customer','2025-08-07',18,944,NULL),(6,100,'Online Customer','2025-08-07',12.6,660.8,NULL),(7,300,'Online Customer','2025-08-07',54,1770,NULL),(8,500,'Online Customer','2025-08-07',104.4,1368.8,NULL),(9,100,'Online Customer','2025-08-07',-1.8,-94.4,NULL),(10,100,'Online Customer','2025-08-07',18,944,NULL),(11,100,'Online Customer','2025-08-07',18,944,NULL),(12,100,'Online Customer','2025-08-07',27,1416,NULL),(13,300,'Online Customer','2025-08-07',61.2,2006,NULL),(14,200,'Online Customer','2025-08-07',31.5,1239,NULL),(15,200,'Online Customer','2025-08-07',28.8,1132.8000000000002,NULL),(16,200,'Online Customer','2025-08-07',36,1416,NULL),(17,100,'Online Customer','2025-08-07',45,2360,NULL),(18,100,'Online Customer','2025-08-08',10.8,566.4,NULL),(19,200,'Online Customer','2025-08-08',41.4,1628.3999999999999,NULL),(20,100,'Online Customer','2025-08-08',27,1947,NULL),(21,100,'Online Customer','2025-08-08',18,944,NULL),(22,100,'Online Customer','2025-08-08',18,944,NULL),(23,100,'Online Customer','2025-08-08',18,944,NULL),(24,100,'Online Customer','2025-08-08',10.8,566.4,NULL),(25,100,'User','2025-08-13',9,59,1),(26,300,'User','2025-08-13',54,354,2),(27,200,'User','2025-08-14',23.4,153.4,7),(28,100,'User','2025-08-14',28.8,188.8,1),(29,100,'User','2025-08-14',5.4,35.4,1),(30,100,'User','2025-08-14',3.6,23.6,1),(31,100,'User','2025-08-14',14.4,94.4,1),(32,400,'User','2025-08-14',72,472,3),(33,400,'User','2025-08-14',72,472,3),(34,100,'User','2025-08-14',32.4,212.4,1),(35,100,'User','2025-08-14',32.4,212.4,1),(36,100,'User','2025-08-14',10.8,70.8,1);
/*!40000 ALTER TABLE `invoiceheader` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manufacturer`
--

DROP TABLE IF EXISTS `manufacturer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manufacturer` (
  `mfg_id` int NOT NULL AUTO_INCREMENT,
  `mfg_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`mfg_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacturer`
--

LOCK TABLES `manufacturer` WRITE;
/*!40000 ALTER TABLE `manufacturer` DISABLE KEYS */;
INSERT INTO `manufacturer` VALUES (1,'Hundai'),(2,'TATA'),(3,'BMW'),(4,'Mahindra');
/*!40000 ALTER TABLE `manufacturer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `model`
--

DROP TABLE IF EXISTS `model`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `model` (
  `model_id` int NOT NULL AUTO_INCREMENT,
  `img_path` varchar(255) DEFAULT NULL,
  `min_qty` int NOT NULL,
  `model_name` varchar(255) DEFAULT NULL,
  `price` double NOT NULL,
  `mfg_id` int NOT NULL,
  `seg_id` int NOT NULL,
  PRIMARY KEY (`model_id`),
  KEY `FKa9twxcy0350gsjcar771xuk2d` (`mfg_id`),
  KEY `FKhldm2r9ujahkkawo940pq9j7r` (`seg_id`),
  CONSTRAINT `FKa9twxcy0350gsjcar771xuk2d` FOREIGN KEY (`mfg_id`) REFERENCES `manufacturer` (`mfg_id`),
  CONSTRAINT `FKhldm2r9ujahkkawo940pq9j7r` FOREIGN KEY (`seg_id`) REFERENCES `segment` (`seg_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `model`
--

LOCK TABLES `model` WRITE;
/*!40000 ALTER TABLE `model` DISABLE KEYS */;
INSERT INTO `model` VALUES (1,'/images/i20.jpg',8,'i20',100,1,1),(2,'/images/verna.jpg',5,'Verna',300,1,3),(3,'/images/creta.jpg',3,'Creta',400,1,4),(4,'/images/tiago.jpg',8,'Tiago',100,2,1),(5,'/images/tigor.jpg',5,'Tigor',300,2,3),(6,'/images/harrier.jpg',3,'Harrier',400,2,4),(7,'/images/1series.jpg',6,'1 Series',200,3,2),(8,'/images/3series.jpg',5,'3 Series',300,3,3),(9,'/images/x5.jpg',2,'X5',500,3,5),(10,'/images/xuv300.jpg',3,'XUV300',400,4,4),(11,'/images/bolero.jpg',3,'Bolero',400,4,4),(12,'/images/thar.jpg',3,'Thar',400,4,4);
/*!40000 ALTER TABLE `model` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `segment`
--

DROP TABLE IF EXISTS `segment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `segment` (
  `seg_id` int NOT NULL AUTO_INCREMENT,
  `seg_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`seg_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `segment`
--

LOCK TABLES `segment` WRITE;
/*!40000 ALTER TABLE `segment` DISABLE KEYS */;
INSERT INTO `segment` VALUES (1,'Small Car'),(2,'Compact Car'),(3,'Sedan'),(4,'SUVs'),(5,'Luxury Car');
/*!40000 ALTER TABLE `segment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sg_mfg_master`
--

DROP TABLE IF EXISTS `sg_mfg_master`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sg_mfg_master` (
  `sgmf_id` int NOT NULL AUTO_INCREMENT,
  `mfg_id` int NOT NULL,
  `seg_id` int NOT NULL,
  PRIMARY KEY (`sgmf_id`),
  KEY `FK1prc5g0cftuck7xoou73g6jan` (`mfg_id`),
  KEY `FKpb2wup0fjo3iurdlxaabu0cnk` (`seg_id`),
  CONSTRAINT `FK1prc5g0cftuck7xoou73g6jan` FOREIGN KEY (`mfg_id`) REFERENCES `manufacturer` (`mfg_id`),
  CONSTRAINT `FKpb2wup0fjo3iurdlxaabu0cnk` FOREIGN KEY (`seg_id`) REFERENCES `segment` (`seg_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sg_mfg_master`
--

LOCK TABLES `sg_mfg_master` WRITE;
/*!40000 ALTER TABLE `sg_mfg_master` DISABLE KEYS */;
INSERT INTO `sg_mfg_master` VALUES (1,1,1),(2,1,3),(3,1,4),(4,2,1),(5,2,3),(6,2,4),(7,3,2),(8,3,3),(9,3,5),(10,4,4);
/*!40000 ALTER TABLE `sg_mfg_master` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `addr` varchar(255) DEFAULT NULL,
  `auth_name` varchar(255) DEFAULT NULL,
  `cell` decimal(38,2) DEFAULT NULL,
  `city` varchar(255) DEFAULT NULL,
  `company_name` varchar(255) DEFAULT NULL,
  `desig` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `holding` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `pin` int NOT NULL,
  `reg_no` decimal(38,2) DEFAULT NULL,
  `role` varchar(255) DEFAULT NULL,
  `st_no` int NOT NULL,
  `state` varchar(255) DEFAULT NULL,
  `tel` decimal(38,2) DEFAULT NULL,
  `username` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'None','AUTH',98765432102.00,'Juhu','None','None','admin@gmail.com','Proprietary','$2a$10$N26wNw2D94lv2rEwYsy6KOm7Tkmj2iY8yvv4KN52hKZ02WWOz9CX2',20007,1.00,'ADMIN',12,'None',675843902823.00,'Admin'),(2,'Juhu','Auth',7432847828.00,'mumbai','some company','CEO','prathamkadave007@gmail.com','Proprietary','$2a$10$4ncU0Zr9TuWiLlsU/Z9pqu1J0d0JPcup1WuDN/uRFmq0tJ5i9PvRm',400122,12.00,'User',1234,'Maharashtra',24626482347.00,'User'),(3,'zdgdgbhdnb','ishh',43675687.00,'Mumbai','mjs the brand','CEO','ishh@gmail.com','Pvt. Ltd','$2a$10$fSlUoqZfjL7Q5e9rqvtJnOIcEEX9rgeKFR.YPfifJWfjTyfW0c9oO',457789,5678789.00,'CEO',38,'gfhgjhkj',46547468743.00,'ishh');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vehicle_detail`
--

DROP TABLE IF EXISTS `vehicle_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vehicle_detail` (
  `config_id` int NOT NULL AUTO_INCREMENT,
  `comp_type` varchar(255) DEFAULT NULL,
  `is_config` varchar(255) DEFAULT NULL,
  `comp_id` int DEFAULT NULL,
  `model_id` int DEFAULT NULL,
  PRIMARY KEY (`config_id`),
  KEY `FKa593xqt4mxktc7m7oupjoguuy` (`comp_id`),
  KEY `FK4be6aw3qg13ivv6yjcgjkb3de` (`model_id`),
  CONSTRAINT `FK4be6aw3qg13ivv6yjcgjkb3de` FOREIGN KEY (`model_id`) REFERENCES `model` (`model_id`),
  CONSTRAINT `FKa593xqt4mxktc7m7oupjoguuy` FOREIGN KEY (`comp_id`) REFERENCES `component` (`comp_id`)
) ENGINE=InnoDB AUTO_INCREMENT=217 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vehicle_detail`
--

LOCK TABLES `vehicle_detail` WRITE;
/*!40000 ALTER TABLE `vehicle_detail` DISABLE KEYS */;
INSERT INTO `vehicle_detail` VALUES (1,'Core','N',1,1),(2,'Core','N',2,1),(3,'Core','N',3,1),(4,'Core','N',4,1),(5,'Core','N',5,1),(6,'Core','N',6,1),(7,'Core','N',1,2),(8,'Core','N',2,2),(9,'Core','N',3,2),(10,'Core','N',4,2),(11,'Core','N',5,2),(12,'Core','N',6,2),(13,'Core','N',1,3),(14,'Core','N',2,3),(15,'Core','N',3,3),(16,'Core','N',4,3),(17,'Core','N',5,3),(18,'Core','N',6,3),(19,'Core','N',1,4),(20,'Core','N',2,4),(21,'Core','N',3,4),(22,'Core','N',4,4),(23,'Core','N',5,4),(24,'Core','N',6,4),(25,'Core','N',1,5),(26,'Core','N',2,5),(27,'Core','N',3,5),(28,'Core','N',4,5),(29,'Core','N',5,5),(30,'Core','N',6,5),(31,'Core','N',1,6),(32,'Core','N',2,6),(33,'Core','N',3,6),(34,'Core','N',4,6),(35,'Core','N',5,6),(36,'Core','N',6,6),(37,'Core','N',1,7),(38,'Core','N',2,7),(39,'Core','N',3,7),(40,'Core','N',4,7),(41,'Core','N',5,7),(42,'Core','N',6,7),(43,'Core','N',1,8),(44,'Core','N',2,8),(45,'Core','N',3,8),(46,'Core','N',4,8),(47,'Core','N',5,8),(48,'Core','N',6,8),(49,'Core','N',1,9),(50,'Core','N',2,9),(51,'Core','N',3,9),(52,'Core','N',4,9),(53,'Core','N',5,9),(54,'Core','N',6,9),(55,'Core','N',1,10),(56,'Core','N',2,10),(57,'Core','N',3,10),(58,'Core','N',4,10),(59,'Core','N',5,10),(60,'Core','N',6,10),(61,'Core','N',1,11),(62,'Core','N',2,11),(63,'Core','N',3,11),(64,'Core','N',4,11),(65,'Core','N',5,11),(66,'Core','N',6,11),(67,'Core','N',1,12),(68,'Core','N',2,12),(69,'Core','N',3,12),(70,'Core','N',4,12),(71,'Core','N',5,12),(72,'Core','N',6,12),(73,'Standard','Y',7,1),(74,'Standard','N',8,1),(75,'Standard','N',11,1),(76,'Standard','Y',12,1),(77,'Standard','Y',7,2),(78,'Standard','N',8,2),(79,'Standard','N',11,2),(80,'Standard','Y',12,2),(81,'Standard','Y',7,3),(82,'Standard','N',8,3),(83,'Standard','N',11,3),(84,'Standard','Y',12,3),(85,'Standard','Y',7,4),(86,'Standard','N',8,4),(87,'Standard','N',11,4),(88,'Standard','Y',12,4),(89,'Standard','Y',7,5),(90,'Standard','N',8,5),(91,'Standard','N',11,5),(92,'Standard','Y',12,5),(93,'Standard','Y',7,6),(94,'Standard','N',8,6),(95,'Standard','N',11,6),(96,'Standard','Y',12,6),(97,'Standard','Y',7,7),(98,'Standard','N',8,7),(99,'Standard','N',11,7),(100,'Standard','Y',12,7),(101,'Standard','Y',7,8),(102,'Standard','N',8,8),(103,'Standard','N',11,8),(104,'Standard','Y',12,8),(105,'Standard','Y',7,9),(106,'Standard','N',8,9),(107,'Standard','N',11,9),(108,'Standard','Y',12,9),(109,'Standard','Y',7,10),(110,'Standard','N',8,10),(111,'Standard','N',11,10),(112,'Standard','Y',12,10),(113,'Standard','Y',7,11),(114,'Standard','N',8,11),(115,'Standard','N',11,11),(116,'Standard','Y',12,11),(117,'Standard','Y',7,12),(118,'Standard','N',8,12),(119,'Standard','N',11,12),(120,'Standard','Y',12,12),(121,'Interior','N',9,1),(122,'Interior','N',13,1),(123,'Interior','Y',16,1),(124,'Interior','Y',21,1),(125,'Interior','N',9,2),(126,'Interior','N',13,2),(127,'Interior','Y',16,2),(128,'Interior','Y',21,2),(129,'Interior','N',9,3),(130,'Interior','N',13,3),(131,'Interior','Y',16,3),(132,'Interior','Y',21,3),(133,'Interior','N',9,4),(134,'Interior','N',13,4),(135,'Interior','Y',16,4),(136,'Interior','Y',21,4),(137,'Interior','N',9,5),(138,'Interior','N',13,5),(139,'Interior','Y',16,5),(140,'Interior','Y',21,5),(141,'Interior','N',9,6),(142,'Interior','N',13,6),(143,'Interior','Y',16,6),(144,'Interior','Y',21,6),(145,'Interior','N',9,7),(146,'Interior','N',13,7),(147,'Interior','Y',16,7),(148,'Interior','Y',21,7),(149,'Interior','N',9,8),(150,'Interior','N',13,8),(151,'Interior','Y',16,8),(152,'Interior','Y',21,8),(153,'Interior','N',9,9),(154,'Interior','N',13,9),(155,'Interior','Y',16,9),(156,'Interior','Y',21,9),(157,'Interior','N',9,10),(158,'Interior','N',13,10),(159,'Interior','Y',16,10),(160,'Interior','Y',21,10),(161,'Interior','N',9,11),(162,'Interior','N',13,11),(163,'Interior','Y',16,11),(164,'Interior','Y',21,11),(165,'Interior','N',9,12),(166,'Interior','N',13,12),(167,'Interior','Y',16,12),(168,'Interior','Y',21,12),(169,'Exterior','Y',23,1),(170,'Exterior','N',24,1),(171,'Exterior','N',25,1),(172,'Exterior','Y',27,1),(173,'Exterior','Y',23,2),(174,'Exterior','N',24,2),(175,'Exterior','N',25,2),(176,'Exterior','Y',27,2),(177,'Exterior','Y',23,3),(178,'Exterior','N',24,3),(179,'Exterior','N',25,3),(180,'Exterior','Y',27,3),(181,'Exterior','Y',23,4),(182,'Exterior','N',24,4),(183,'Exterior','N',25,4),(184,'Exterior','Y',27,4),(185,'Exterior','Y',23,5),(186,'Exterior','N',24,5),(187,'Exterior','N',25,5),(188,'Exterior','Y',27,5),(189,'Exterior','Y',23,6),(190,'Exterior','N',24,6),(191,'Exterior','N',25,6),(192,'Exterior','Y',27,6),(193,'Exterior','Y',23,7),(194,'Exterior','N',24,7),(195,'Exterior','N',25,7),(196,'Exterior','Y',27,7),(197,'Exterior','Y',23,8),(198,'Exterior','N',24,8),(199,'Exterior','N',25,8),(200,'Exterior','Y',27,8),(201,'Exterior','Y',23,9),(202,'Exterior','N',24,9),(203,'Exterior','N',25,9),(204,'Exterior','Y',27,9),(205,'Exterior','Y',23,10),(206,'Exterior','N',24,10),(207,'Exterior','N',25,10),(208,'Exterior','Y',27,10),(209,'Exterior','Y',23,11),(210,'Exterior','N',24,11),(211,'Exterior','N',25,11),(212,'Exterior','Y',27,11),(213,'Exterior','Y',23,12),(214,'Exterior','N',24,12),(215,'Exterior','N',25,12),(216,'Exterior','Y',27,12);
/*!40000 ALTER TABLE `vehicle_detail` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-15 22:19:05
