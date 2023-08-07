/*
 Author: Andre Burke
 Created Date: 2023-08-06
 Change List:
    - Date: 2023-08-06
      Description: initial table creation and inserts
    - Date: 
      Description: 
 */
CREATE TABLE IF NOT EXISTS post_types (
    id SERIAL PRIMARY KEY,
    post_type_name VARCHAR(50) NOT NULL,
    description VARCHAR(150),
    post_type_value SMALLINT NOT NULL CHECK (post_type_value >= 0 AND post_type_value <= 5)
);

INSERT INTO post_types (post_type_name, post_type_value, description)
VALUES
    ('None', 0, 'Default of None if a value was not provided for the post type.'),
    ('Inspiration', 1, 'User is looking for inspiration from other work.'),
    ('ProjectWork', 2, 'User wants to show off their work to potentially inspire others.');


/*
 Author: Andre Burke
 Created Date: 2023-08-06
 Change List:
    - Date: 2023-08-06
      Description: initial table creation and fk constraint
    - Date: 
      Description: 
 */
CREATE TABLE IF NOT EXISTS posts (
    id SERIAL PRIMARY KEY,
    title VARCHAR(100) NOT NULL,
    body TEXT NOT NULL,
    post_type_id INTEGER NOT NULL
);

ALTER TABLE posts
    ADD CONSTRAINT fk_posts_post_type_id
        FOREIGN KEY (post_type_id) REFERENCES post_types (id);