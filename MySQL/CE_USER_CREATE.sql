DROP TABLE IF EXISTS `cryptoeditor`.`ce_user`;
CREATE TABLE  `cryptoeditor`.`ce_user` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `email` varchar(64) NOT NULL,
  `profile` varchar(64) NOT NULL,
  `fullname` varchar(64) NOT NULL,
  `license` varchar(64) NOT NULL,
  `encrypted_license` varchar(128) NOT NULL,
  `status` int(10) unsigned NOT NULL,
  `expiration` datetime NOT NULL,
  `lastupdate` datetime NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;