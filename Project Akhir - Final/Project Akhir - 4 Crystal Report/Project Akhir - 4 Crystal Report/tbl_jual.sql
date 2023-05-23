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
-- Table structure for table `tbl_jual`
--

CREATE TABLE `tbl_jual` (
  `nojual` varchar(10) NOT NULL,
  `tgljual` date NOT NULL,
  `itemjual` int(30) NOT NULL,
  `totaljual` int(30) NOT NULL,
  `metode` varchar(50) NOT NULL,
  `kodepembeli` varchar(4) NOT NULL,
  `kodeadmin` varchar(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_jual`
--

INSERT INTO `tbl_jual` (`nojual`, `tgljual`, `itemjual`, `totaljual`, `metode`, `kodepembeli`, `kodeadmin`) VALUES
('T001', '2023-05-17', 4, 2147483647, 'Cash', 'P001', 'ADM001'),
('T002', '2023-05-17', 1, 500000000, 'Credit', 'P002', 'ADM001'),
('T003', '2023-05-17', 5, 2147483647, 'Cash', 'P003', 'ADM001'),
('T004', '2023-05-18', 2, 1185000000, 'Cash', 'P001', 'ADM001'),
('T005', '2023-05-20', 4, 2147483647, 'Cash', 'P002', 'ADM001'),
('T006', '2023-05-20', 4, 2147483647, 'Credit', 'P004', 'ADM001'),
('T007', '2023-05-20', 1, 500000000, 'Cash', 'P003', 'ADM001'),
('T008', '2023-05-20', 1, 650000000, 'Cash', 'P004', 'ADM001'),
('T009', '2023-05-23', 3, 1800000000, 'Cash', 'P003', 'ADM001'),
('T010', '2023-05-23', 1, 650000000, 'Credit', 'P003', 'ADM001');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_jual`
--
ALTER TABLE `tbl_jual`
  ADD PRIMARY KEY (`nojual`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
