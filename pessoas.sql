info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 2.2.4-servicing-10062 initialized 'CadastroPessoaContext' using provider 'Pomelo.EntityFrameworkCore.MySql' with options: None
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Pessoas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Nome` longtext NULL,
    `Cpf` longtext NULL,
    `Idade` double NOT NULL,
    `Peso` double NOT NULL,
    `Altura` double NOT NULL,
    `Imc` double NOT NULL,
    CONSTRAINT `PK_Pessoas` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190528195826_init', '2.2.4-servicing-10062');