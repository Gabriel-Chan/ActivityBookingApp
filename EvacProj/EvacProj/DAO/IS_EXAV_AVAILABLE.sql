CREATE OR REPLACE
FUNCTION is_exav_available
(
	pexav_id IN NUMBER
)
RETURN NUMBER
IS
  exavAvail NUMBER;
BEGIN
SELECT COUNT(exav_id)
    INTO exavAvail
		FROM apply
		WHERE exav_id = pexav_id AND applicant_username = USER;
    
  IF exavAvail > 0 THEN
		RETURN 0;
	ELSE
		RETURN 1;
	END IF;
END;