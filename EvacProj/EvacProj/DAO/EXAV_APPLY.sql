--Gabriel Chan
create or replace 
PROCEDURE exav_apply
(
	pexav_id IN NUMBER,
	pmonth IN NUMBER,
	psuccess OUT NUMBER
)
IS
  numApps NUMBER;
  maxApps NUMBER;
BEGIN
	SELECT COUNT(*) INTO numApps FROM apply WHERE exav_id = pexav_id AND month = pmonth AND applicant_username = USER;
  SELECT max_applicants INTO maxApps FROM exav WHERE id = pexav_id;
  IF numApps >= maxApps THEN
    psuccess := 0;
  ELSE
    INSERT INTO apply(applicant_username,exav_id,month) VALUES (USER, pexav_id,pmonth);
    psuccess := 1;
  END IF;
END;