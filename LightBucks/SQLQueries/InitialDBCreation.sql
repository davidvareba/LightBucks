USE MASTER
GO

IF NOT EXISTS (
	SELECT [name]
	FROM sys.databases
	WHERE [name] = N'LightBucks'
	)
CREATE DATABASE LightBucks
GO

USE LightBucks
GO

DROP TABLE IF EXISTS Coffee;
DROP TABLE IF EXISTS Snacks;
DROP TABLE IF EXISTS Tea;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS Contact;
DROP TABLE IF EXISTS [User];

CREATE TABLE Coffee (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	Price INTEGER  NOT NULL,
	Descriptions VARCHAR(255) NOT NULL,
	ImgURL VARCHAR(255) NOT NULL,
	userId INTEGER NOT NULL,
	CONSTRAINT FK_Coffee_Users FOREIGN KEY (UsersId) REFERENCES Users(Id) ON DELETE CASCADE,
	CONSTRAINT FK_Coffee_User FOREIGN KEY (UserId) REFERENCES [User](Id) ON DELETE CASCADE,
	);

CREATE TABLE Snacks (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	Price INTEGER  NOT NULL,
	Descriptions VARCHAR(255) NOT NULL,
	ImgURL VARCHAR(255) NOT NULL,
	userId INTEGER NOT NULL,
	CONSTRAINT FK_Snacks_Users FOREIGN KEY (UsersId) REFERENCES Users(Id) ON DELETE CASCADE,
	CONSTRAINT FK_Snacks_User FOREIGN KEY (UserId) REFERENCES [User](Id) ON DELETE CASCADE,
	);

CREATE TABLE Tea (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	Price INTEGER  NOT NULL,
	Descriptions VARCHAR(255) NOT NULL,
	ImgURL VARCHAR(255) NOT NULL,
	userId INTEGER NOT NULL,
	CONSTRAINT FK_Tea_Users FOREIGN KEY (UsersId) REFERENCES Users(Id) ON DELETE CASCADE,
	CONSTRAINT FK_Tea_User FOREIGN KEY (UserId) REFERENCES [User](Id) ON DELETE CASCADE,
	);

CREATE TABLE Users (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	Phone VARCHAR(55) NOT NULL,
	Email VARCHAR(55) NOT NULL,
	ImgURL VARCHAR(255) NOT NULL,
	);

CREATE TABLE Contact (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	Phone INTEGER  NOT NULL,
	Descriptions VARCHAR(255) NOT NULL,
	Email VARCHAR(55) NOT NULL,
	userId INTEGER NOT NULL,
	CONSTRAINT FK_Contact_Users FOREIGN KEY (UsersId) REFERENCES Users(Id) ON DELETE CASCADE,
	CONSTRAINT FK_Contact_User FOREIGN KEY (UserId) REFERENCES [User](Id) ON DELETE CASCADE,
	);

CREATE TABLE [User] (
	Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(55) NOT NULL,
	Phone VARCHAR(55) NOT NULL,
	[Type] INTEGER NOT NULL,
);

--Type 1 - Buyer, Type - 2 Seller
INSERT INTO COFFEE ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Latte', '10', 'shot of espresso and steamed milk with just a touch of foam', 'https://www.netmeds.com/images/cms/wysiwyg/blog/Post/2018/10/coffee_its_benefits_898_1_.jpg', 1, 3)
INSERT INTO COFFEE ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Café au Lait', '10', 'Café au lait is perfect for the coffee minimalist who wants a bit more flavor', 'https://coolbrew.com/wp-content/uploads/HotCAL.jpg', 2, 3)
INSERT INTO COFFEE ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Macchiato', '10', 'sweet blended lattee coffee', 'https://coffeeaffection.com/wp-content/uploads/2019/08/Espresso-macchiato.jpeg', 1, 2)
INSERT INTO COFFEE ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Expresso', '10', 'An espresso shot can be served solo or used as the foundation of most coffee drinks', 'https://s3.amazonaws.com/secretsaucefiles/photos/images/000/170/822/large/espresso.jpg?1499291377', 2, 1)
INSERT INTO COFFEE ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Cappuccino', '10', 'made with more foam than steamed milk, often with a sprinkle of cocoa powder or cinnamon on top', 'https://coffeeaffection.com/wp-content/uploads/2019/08/A-cappuccino-e1596492148544.jpg', 3, 6)
INSERT INTO COFFEE ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Black', '10', 'Black coffee is as simple as it gets with ground coffee beans steeped in hot water, served warm', 'https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG', 2, 4)
INSERT INTO COFFEE ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Americano', '10', 'an espresso shot diluted in hot water', 'http://cdn.shopify.com/s/files/1/0219/5410/articles/Delicious-Homemade-Americano_1200x1200.jpg?v=1605897263', 5, 6)


INSERT INTO TEA ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Black Tea', '10', 'Black tea is withered, fully oxidized and dried. Black tea commonly yields a hearty, amber-colored brew.', 'https://www.netmeds.com/images/cms/wysiwyg/blog/Post/2018/10/coffee_its_benefits_898_1_.jpg', 1, 3)
INSERT INTO TEA ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Green Tea', '10', 'Green tea production endeavors to avoid the oxidation of the tea leaves, in order to retain its natural green color and fresh flavor. ', 'https://coolbrew.com/wp-content/uploads/HotCAL.jpg', 2, 3)
INSERT INTO TEA ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('White Tea', '10', 'white tea is simply withered and dried, causing a very light oxidation. Its flavor is most similar to that of green tea, but is usually more creamy, soft and sweet.', 'https://coffeeaffection.com/wp-content/uploads/2019/08/Espresso-macchiato.jpeg', 1, 2)
INSERT INTO TEA ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Yellow Tea', '10', 'Yellow tea is the rarest type of tea. It is similarly processed to green tea, but is more slowly dried to make the leaves take on a yellow color.', 'https://s3.amazonaws.com/secretsaucefiles/photos/images/000/170/822/large/espresso.jpg?1499291377', 2, 1)
INSERT INTO TEA ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Herbal Tea', '10', 'Herbal tea is simply the combination of boiling water and botanicals like fruits, flowers, barks, herbs, mints, spices, roots, berries and seeds.', 'https://coffeeaffection.com/wp-content/uploads/2019/08/A-cappuccino-e1596492148544.jpg', 3, 6)
INSERT INTO TEA ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Pu-erh', '10', 'Pu-erh (also spelled pu-er) comes exclusively from China and is famous for its distinctively earthy flavor. ', 'https://upload.wikimedia.org/wikipedia/commons/4/45/A_small_cup_of_coffee.JPG', 2, 4)
INSERT INTO TEA ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Oolong Tea', '10', 'Oolong tea is produced mainly in China and Taiwan and is only partially oxidized.', 'http://cdn.shopify.com/s/files/1/0219/5410/articles/Delicious-Homemade-Americano_1200x1200.jpg?v=1605897263', 5, 6)

INSERT INTO SNACKS ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Breakfast Dogs', '10', 'Breakfast Dog > Bacon, Egg and Cheese', 'https://hips.hearstapps.com/del.h-cdn.co/assets/17/24/640x958/gallery-1497635570-delish-breakfast-dogs-pin-2.jpg?resize=980:*', 1, 3)
INSERT INTO SNACKS ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Huevos Rancheros Sandwich', '10', 'Perfecto.', 'https://coolbrew.com/wp-content/uploads/HotCAL.jpg', 2, 3)
INSERT INTO SNACKS ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Maple Bourbon Chicken & Waffle Sandwich', '10', 'no-fuss sandwich stacked with fried chicken, bacon, fresh cornbread waffles, and bourbon-laced maple syrup', 'https://hips.hearstapps.com/del.h-cdn.co/assets/17/23/640x959/gallery-1496768778-chicken-and-waffles-pinterest-3.jpg?resize=980:*', 1, 2)
INSERT INTO SNACKS ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Bacon Egg and Cheese Roll-Ups', '10', 'A new way to low-carb breakfast.', 'https://hips.hearstapps.com/del.h-cdn.co/assets/17/18/1494024426-delish-bacon-egg-cheese-roll-ups-pin-1.jpg?crop=0.999546485260771xw:1xh;center,top&resize=980:*', 2, 1)
INSERT INTO SNACKS ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Breakfast Burgers', '10', 'Breakfast for dinner, meet burger for dinner.', 'https://hips.hearstapps.com/del.h-cdn.co/assets/17/18/640x959/gallery-1494024376-delish-breakfast-burgers-pin-02.jpg?resize=980:*', 3, 6)
INSERT INTO SNACKS ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Bacon Weave Breakfast Sandwich', '10', 'Bacon >>> bread.', 'https://hips.hearstapps.com/del.h-cdn.co/assets/17/15/768x768/square-1492209054-funs-bacon.jpg?resize=768:*', 2, 4)
INSERT INTO SNACKS ([Name], Price, Descriptions, ImgUrl, UsersId, UserId) VALUES ('Giant Breakfast Sandwich', '10', 'The biggest BEC you ever did see.', 'https://hips.hearstapps.com/del.h-cdn.co/assets/17/06/640x958/gallery-1486738811-delish-giant-breakfast-sandwich-pin-3.jpg?resize=980:*', 5, 6)


INSERT INTO [User] ([Name], Phone, [Type]) VALUES ('Jimmy', '123-456-7890', 1)
INSERT INTO [User] ([Name], Phone, [Type]) VALUES ('Jameka', '567-891-2345', 2)
INSERT INTO [User] ([Name], Phone, [Type]) VALUES ('Brain', '345-678-9012', 1)
INSERT INTO [User] ([Name], Phone, [Type]) VALUES ('Dylan', '456-789-1234', 2)

INSERT INTO Users ([Name], Phone, Email, ImgUrl, ImgURL) VALUES ('David Vadana', '615-509-0000', 'contact@thevadanagroup.com', 'https://ecommerce2.apple.com/content/dam/b2b/products/en/mac/macbook-pro/MacBook_Pro_14-in_Silver_PDP_Image_Position-1_en-US.jpg')
INSERT INTO Users ([Name], Phone, Email, ImgUrl, ImgURL) VALUES ('David Vadana', '615-509-0000', 'contact@thevadanagroup.com', 'https://ecommerce2.apple.com/content/dam/b2b/products/en/mac/macbook-pro/MacBook_Pro_14-in_Silver_PDP_Image_Position-1_en-US.jpg')
INSERT INTO Users ([Name], Phone, Email, ImgUrl, ImgURL) VALUES ('David Vadana', '615-509-0000', 'contact@thevadanagroup.com', 'https://ecommerce2.apple.com/content/dam/b2b/products/en/mac/macbook-pro/MacBook_Pro_14-in_Silver_PDP_Image_Position-1_en-US.jpg')
INSERT INTO Users ([Name], Phone, Email, ImgUrl, ImgURL) VALUES ('David Vadana', '615-509-0000', 'contact@thevadanagroup.com', 'https://ecommerce2.apple.com/content/dam/b2b/products/en/mac/macbook-pro/MacBook_Pro_14-in_Silver_PDP_Image_Position-1_en-US.jpg')
INSERT INTO Users ([Name], Phone, Email, ImgUrl, ImgURL) VALUES ('David Vadana', '615-509-0000', 'contact@thevadanagroup.com', 'https://ecommerce2.apple.com/content/dam/b2b/products/en/mac/macbook-pro/MacBook_Pro_14-in_Silver_PDP_Image_Position-1_en-US.jpg')