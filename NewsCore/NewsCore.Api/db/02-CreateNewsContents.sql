CREATE TABLE IF NOT EXISTS "NewsContents" (
		"ID" SERIAL PRIMARY KEY,
		"NewsBlockID" INTEGER NOT NULL references "NewsBlocks"("ID"),
		"ContentType" INTEGER NOT NULL,
		"Detail" VARCHAR(2000) NOT NULL
	);