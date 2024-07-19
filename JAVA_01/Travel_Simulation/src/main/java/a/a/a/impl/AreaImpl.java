package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.AreaDAO;
import a.a.a.service.AreaService;
import a.a.a.util.PagingVO;

@Service("areaService")
public class AreaImpl implements AreaService {

	@Resource(name = "areaDAO")
	private AreaDAO areaDAO;

	// 조회
	@Override
	public ArrayList<HashMap<String, Object>> areaAllSelectChk() throws SQLException {

		return areaDAO.areaAllSelectChk();
	}
	
	// 선택조회
	@Override
	public ArrayList<HashMap<String, Object>> areaSelectChk(HashMap<String, Object> hm) throws SQLException {

		return areaDAO.areaSelectChk(hm);
	}
	
	// 관광지 정보
	@Override
	public ArrayList<HashMap<String, Object>> areaInfoChk(HashMap<String, Object> hm) throws SQLException {

		return areaDAO.areaInfoChk(hm);
	}

	@Override
	public ArrayList<HashMap<String, Object>> CNTinfo() throws SQLException {
		return areaDAO.CNTinfo();
	}
	
	//selectBox
	@Override
	public ArrayList<HashMap<String, Object>> selectBox() throws SQLException {
		return areaDAO.selectBox();
	}
	
	//oneSelectBox
	@Override
	public HashMap<String, Object> oneSelectBox(HashMap<String, Object> hm) throws SQLException {
		return areaDAO.oneSelectBox(hm);
	}

	/**
	 * 전체 게시글 수 확인
	 */
	@Override
	public int areaCount(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return areaDAO.areaCount(vo);
	}

	/**
	 * 무한 스크롤 처리
	 */
	@Override
	public ArrayList<HashMap<String, Object>> areaSelect(PagingVO vo) throws SQLException {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) areaDAO.areaSelect(vo);
	}
	
	//리뷰불러오기
	@Override
	public ArrayList<HashMap<String, Object>> reviewSelect(HashMap<String, Object> hm) throws SQLException {
		return areaDAO.reviewSelect(hm);
	}

}
