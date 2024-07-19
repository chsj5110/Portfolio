package a.a.a.service;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import a.a.a.util.PagingVO;

public interface AreaService {
	
	public ArrayList<HashMap<String, Object>> areaAllSelectChk() throws SQLException;
	public ArrayList<HashMap<String, Object>> areaSelectChk(HashMap<String, Object> hm) throws SQLException;
	public ArrayList<HashMap<String, Object>> areaInfoChk(HashMap<String, Object> hm) throws SQLException;
	public ArrayList<HashMap<String, Object>> CNTinfo() throws SQLException;
	public ArrayList<HashMap<String, Object>> selectBox() throws SQLException;
	public HashMap<String, Object> oneSelectBox(HashMap<String, Object> hm) throws SQLException;
	public int areaCount(PagingVO vo) throws SQLException;
	public Object areaSelect(PagingVO vo) throws SQLException;
	public ArrayList<HashMap<String, Object>> reviewSelect(HashMap<String, Object> hm) throws SQLException;
	
}