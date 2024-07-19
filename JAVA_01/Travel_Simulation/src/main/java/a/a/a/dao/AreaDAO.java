package a.a.a.dao;

import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;

import a.a.a.util.PagingVO;

@Repository("areaDAO")
public class AreaDAO extends AbstractDAO {
	
	// 조회
	public ArrayList<HashMap<String, Object>> areaAllSelectChk() {

		return (ArrayList<HashMap<String, Object>>) selectList("Area.areaAllSelectChk");

	}
		
	// 선택조회
	public ArrayList<HashMap<String, Object>> areaSelectChk(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("Area.areaSelectChk", hm);

	}
	
	// 관광지 정보
	public ArrayList<HashMap<String, Object>> areaInfoChk(HashMap<String, Object> hm) {
			
		return (ArrayList<HashMap<String, Object>>) selectList("Area.areaInfoChk", hm);

	}

	public ArrayList<HashMap<String, Object>> CNTinfo() {
		return (ArrayList<HashMap<String, Object>>) selectList("Area.CNTinfo");
	}

	/**
	 * 게시글 수 조회
	 * @param vo
	 * @return
	 */
	public int areaCount(PagingVO vo) {
		// TODO Auto-generated method stub
		return (int) selectOne("Area.areaCount",vo);
	}

	/**
	 * 무한 스크롤 처리
	 * @param vo
	 * @return
	 */
	public ArrayList<HashMap<String, Object>> areaSelect(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("Area.areaSelect",vo);
	}
	
	//selectBox
	public ArrayList<HashMap<String, Object>> selectBox() {
		return (ArrayList<HashMap<String, Object>>) selectList("Area.selectBox");
	}
	
	//oneSelectBox
	public HashMap<String, Object> oneSelectBox(HashMap<String, Object> hm) {
		return (HashMap<String, Object>) selectOne("Area.oneSelectBox", hm);
	}
	
	// 리뷰불러오기
	public ArrayList<HashMap<String, Object>> reviewSelect(HashMap<String, Object> hm) {
				
		return (ArrayList<HashMap<String, Object>>) selectList("Area.reviewSelect", hm);

	}

}
