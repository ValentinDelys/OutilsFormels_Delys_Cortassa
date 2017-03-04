-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Client :  127.0.0.1
-- Généré le :  Sam 04 Mars 2017 à 15:37
-- Version du serveur :  5.7.14
-- Version de PHP :  5.6.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `outils_formels`
--

-- --------------------------------------------------------

--
-- Structure de la table `card`
--

CREATE TABLE `card` (
  `cardID` int(11) NOT NULL,
  `number` varchar(128) NOT NULL,
  `expiration` date NOT NULL,
  `type` int(1) UNSIGNED NOT NULL COMMENT 'Type de la CB (0 = VISA, 1 = MasterCard)',
  `fk_userID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `card`
--

INSERT INTO `card` (`cardID`, `number`, `expiration`, `type`, `fk_userID`) VALUES
(17, 'XtFJQMF+zSsho9iJnijwgVMTvxXLfvm+untaECskhA0iumqKGuGtpx6Si4yzYEEtCLmxB4RpWcgas2pFlrJzA8Q9+wxkOA8A99QRToyDzcgXiKScmJrxVsSYK2too6c7', '2017-03-01', 0, 5),
(18, 'cNKpWiRvjAPIjYfvl0Pt1kiLoi8MVqwzK0YNU2F2rA1nOMgvHdwOIE8V2M2couYbG/MLpQ1ITxrfO/6QsVlCehVuYjbdQTv4eHpn1kvw2dZBebemeSJq98nVz5xHNn+t', '2019-07-01', 1, 5),
(19, 'SQbFZyQhxJLj671pHd1xbcenk+XSsP7LJHvFmatAiM84g5lvFgqfdZnN+GRrnrAC3O4vbEXMDovmyAaqp3PwLUFcn5wzif4IrMysEJ/nOQ2+ixxIGxAJJchcxsJL61S4', '2018-10-01', 0, 6),
(20, 'lz7NP+UF3/lMz57b9DYfyVDQSNiove/EDbVFmez3QzWk/Fs0Pqm0N0tU21ht1RqeC0BWUsiWTqd3yWIIlZj5rhNUoivAxTZ7rwwtqWTqIAR6GLS3uCoOh38zDcDNn1E6', '2019-02-01', 1, 6);

-- --------------------------------------------------------

--
-- Structure de la table `user`
--

CREATE TABLE `user` (
  `userID` int(11) NOT NULL,
  `firstName` varchar(40) NOT NULL,
  `lastName` varchar(40) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(60) NOT NULL,
  `login` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `user`
--

INSERT INTO `user` (`userID`, `firstName`, `lastName`, `email`, `password`, `login`) VALUES
(5, 'Valentin', 'Delys', 'valentin.delys@gmail.com', '$2a$10$NGhtHEfIpnuUIx85G/7NfOnZknYT4vHD.3PRdn.J4g1Lm7Zgs4YmS', 'vdelys'),
(6, 'Charlie', 'Cortassa', 'charlie.cortassa@gmail.com', '$2a$10$n0bJJ5uZ/TJXUFqejqK/t.BEtjgOJb.jspZGPGiO3m0iglcijZzxG', 'ccortassa');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `card`
--
ALTER TABLE `card`
  ADD PRIMARY KEY (`cardID`),
  ADD KEY `fk_userID` (`fk_userID`) USING BTREE;

--
-- Index pour la table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userID`),
  ADD UNIQUE KEY `login` (`login`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `card`
--
ALTER TABLE `card`
  MODIFY `cardID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT pour la table `user`
--
ALTER TABLE `user`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `card`
--
ALTER TABLE `card`
  ADD CONSTRAINT `Fk_UserID` FOREIGN KEY (`fk_userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
