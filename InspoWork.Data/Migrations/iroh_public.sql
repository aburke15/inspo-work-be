/*
 Author: Andre Burke
 Created Date: 2023-08-06
 Change List:
    - Date: 2023-08-06
      Description: initial table creation
    - Date: 
      Description: 
 */
CREATE TABLE IF NOT EXISTS posts (
    id SERIAL PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    body TEXT NOT NULL,
    post_type SMALLINT NOT NULL CHECK (post_type >= 0 AND post_type <= 5)
);