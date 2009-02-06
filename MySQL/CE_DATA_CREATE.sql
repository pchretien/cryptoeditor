DROP TABLE IF EXISTS `cryptoeditor`.`ce_data`;
CREATE TABLE  `cryptoeditor`.`ce_data` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `email` varchar(64) NOT NULL,
  `profile` varchar(64) NOT NULL,
  `plugin` varchar(64) NOT NULL,
  `data` longtext,
  `lastupdate` datetime NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;