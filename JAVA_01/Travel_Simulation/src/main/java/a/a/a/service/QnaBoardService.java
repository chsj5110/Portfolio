package a.a.a.service;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import a.a.a.util.PagingVO;

public interface QnaBoardService {

	public HashMap<String, Object> readQB(HashMap<String, Object> hm) throws SQLException;

	public void insertQB(HashMap<String, Object> map) throws SQLException;

	public void updateQB(HashMap<String, Object> hm) throws SQLException;

	public void deleteQB(HashMap<String, Object> hm) throws SQLException;

	public ArrayList<HashMap<String, Object>> answerShowQB(HashMap<String, Object> hm) throws SQLException;

	public void answerInsertQB(HashMap<String, Object> hm) throws SQLException;

	public void deleteAnswer(HashMap<String, Object> hm) throws SQLException;

	public Object selectQB(PagingVO vo) throws SQLException;

	public int countQB(PagingVO vo) throws SQLException;

}
