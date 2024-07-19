package a.a.a.dao;


import java.sql.SQLException;

import org.springframework.stereotype.Repository;


@Repository("commonDAO")
public class CommonDAO extends AbstractDAO{
	public String selectGetToDate() throws SQLException {
		return (String) selectOne("comm.selectGetToDate");
	}
	
}