DELIMITER //

CREATE PROCEDURE GetTodos()
BEGIN
    SELECT Id, Username, Description, IsDone, TargetDate FROM gettodomodels;
END //

DELIMITER ;

DELIMITER //

CREATE PROCEDURE GetTodosByUsername(IN username_param VARCHAR(50))
BEGIN
    SELECT Id, Username, Description, IsDone, TargetDate 
    FROM gettodomodels 
    WHERE Username = username_param;
END //

DELIMITER ;
DELIMITER //

CREATE PROCEDURE CreateTodo(
    IN username_param VARCHAR(50),
    IN description_param TEXT,
    IN isdone_param BOOLEAN,
    IN targetdate_param DATETIME
)
BEGIN
    INSERT INTO gettodomodels (Username, Description, IsDone, TargetDate)
    VALUES (username_param, description_param, isdone_param, targetdate_param);
END //

DELIMITER ;
DELIMITER //

CREATE PROCEDURE UpdateTodo(
    IN id_param INT,
    IN username_param VARCHAR(50),
    IN description_param TEXT,
    IN isdone_param BOOLEAN,
    IN targetdate_param DATETIME
)
BEGIN
    UPDATE gettodomodels 
    SET Username = username_param, 
        Description = description_param, 
        IsDone = isdone_param, 
        TargetDate = targetdate_param
    WHERE Id = id_param;
END //

DELIMITER ;
DELIMITER //

CREATE PROCEDURE DeleteTodo(
    IN id_param INT
)
BEGIN
    DELETE FROM gettodomodels WHERE Id = id_param;
END //

DELIMITER ;
-- Todo 추가
CALL CreateTodo('john', 'Study Blazor', FALSE, '2025-03-10');

-- 모든 Todo 조회
CALL GetTodos();

-- 특정 사용자 조회
CALL GetTodosByUsername('john');

-- Todo 수정
CALL UpdateTodo(1, 'john', 'Learn ASP.NET Core', TRUE, '2025-03-15');

-- Todo 삭제
CALL DeleteTodo(1);
