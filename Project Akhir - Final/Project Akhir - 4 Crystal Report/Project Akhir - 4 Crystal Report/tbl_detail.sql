-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 23, 2023 at 11:46 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_projekakhir`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_detail`
--

CREATE TABLE `tbl_detail` (
  `nojual` varchar(10) NOT NULL,
  `kodemobil` varchar(6) NOT NULL,
  `namamobil` varchar(50) NOT NULL,
  `harga` int(30) NOT NULL,
  `jumlahjual` int(30) NOT NULL,
  `subtotal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_detail`
--

INSERT INTO `tbl_detail` (`nojual`, `kodemobil`, `namamobil`, `harga`, `jumlahjual`, `subtotal`) VALUES
('T001', 'MBL001', 'Everest', 650000000, 2, 1300000000),
('T001', 'MBL002', 'Hilux', 535000000, 2, 1070000000),
('T002', 'MBL003', 'Civic', 500000000, 1, 500000000),
('T003', 'MBL001', 'Everest', 650000000, 2, 1300000000),
('T003', 'MBL002', 'Hilux', 535000000, 3, 1605000000),
('T004', 'MBL001', 'Everest', 650000000, 1, 650000000),
('T004', 'MBL002', 'Hilux', 535000000, 1, 535000000),
('T005', 'MBL001', 'Everest', 650000000, 2, 1300000000),
('T005', 'MBL003', 'Civic', 500000000, 2, 1000000000),
('T006', 'MBL001', 'Everest', 650000000, 2, 1300000000),
('T006', 'MBL002', 'Hilux', 535000000, 2, 1070000000),
('T007', 'MBL003', 'Civic', 500000000, 1, 500000000),
('T008', 'MBL001', 'Everest', 650000000, 1, 650000000),
('T009', 'MBL001', 'Everest', 650000000, 2, 1300000000),
('T009', 'MBL003', 'Civic', 500000000, 1, 500000000),
('T010', 'MBL001', 'Everest', 650000000, 1, 650000000);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
