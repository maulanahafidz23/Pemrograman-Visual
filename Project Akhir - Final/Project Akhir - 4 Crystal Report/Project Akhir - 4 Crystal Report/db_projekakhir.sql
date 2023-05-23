-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 23, 2023 at 11:42 AM
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
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `kodeadmin` varchar(6) NOT NULL,
  `namaadmin` varchar(50) NOT NULL,
  `password` varchar(30) NOT NULL,
  `leveladmin` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_admin`
--

INSERT INTO `tbl_admin` (`kodeadmin`, `namaadmin`, `password`, `leveladmin`) VALUES
('ADM001', 'Maulana', '070', 'ADMIN'),
('ADM002', 'Amin', '076', 'Admin'),
('ADM003', 'Mahsa', '065', 'Admin');

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

-- --------------------------------------------------------

--
-- Table structure for table `tbl_mobil`
--

CREATE TABLE `tbl_mobil` (
  `kodemobil` varchar(6) NOT NULL,
  `merk` varchar(20) NOT NULL,
  `namamobil` varchar(50) NOT NULL,
  `harga` int(30) NOT NULL,
  `jumlah` int(5) NOT NULL,
  `satuan` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_mobil`
--

INSERT INTO `tbl_mobil` (`kodemobil`, `merk`, `namamobil`, `harga`, `jumlah`, `satuan`) VALUES
('MBL001', 'Ford', 'Everest', 650000000, 12, 'Unit'),
('MBL002', 'Toyota', 'Hilux', 535000000, 5, 'Unit'),
('MBL003', 'Honda', 'Civic', 500000000, 1, 'Unit');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_pelanggan`
--

CREATE TABLE `tbl_pelanggan` (
  `kodepembeli` varchar(4) NOT NULL,
  `namapembeli` varchar(50) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `nomor` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_pelanggan`
--

INSERT INTO `tbl_pelanggan` (`kodepembeli`, `namapembeli`, `alamat`, `nomor`) VALUES
('P001', 'Budi', 'Jl. Juanda', '08111222333444'),
('P002', 'Syifa', 'Jl. Antasari', '082555666777'),
('P003', 'Alex', 'Jl. Jakarta', '083888999111'),
('P004', 'SIlvi', 'Jl. Bandung', '0812233118855');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  ADD PRIMARY KEY (`kodeadmin`);

--
-- Indexes for table `tbl_jual`
--
ALTER TABLE `tbl_jual`
  ADD PRIMARY KEY (`nojual`);

--
-- Indexes for table `tbl_mobil`
--
ALTER TABLE `tbl_mobil`
  ADD PRIMARY KEY (`kodemobil`);

--
-- Indexes for table `tbl_pelanggan`
--
ALTER TABLE `tbl_pelanggan`
  ADD PRIMARY KEY (`kodepembeli`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
