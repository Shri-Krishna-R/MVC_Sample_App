create database MVC_Ajmera

use MVC_Ajmera

CREATE TABLE  Book( 
Bookid int NOT NULL, 
Booktitle  VARCHAR(35) NOT NULL,
author VARCHAR(35) NOT NULL,
authorId int NOT NULL,
PRIMARY KEY (Bookid))

CREATE TABLE Author( 
authorid int NOT NULL,
authorName  VARCHAR(35) NOT NULL,
PRIMARY KEY (authorid))



select * from Book
select * From Author

