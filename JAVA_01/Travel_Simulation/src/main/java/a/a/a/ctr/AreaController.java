package a.a.a.ctr;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Locale;

import javax.annotation.Resource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.AreaService;
import a.a.a.util.PagingVO;

/**
 * Handles requests for the application home page.
 */
@Controller
public class AreaController {
	
	@Resource(name = "areaService")
	private AreaService areaService;
	
	private static final Logger logger = LoggerFactory.getLogger(AreaController.class);
	private ModelAndView mv = new ModelAndView();
	private ModelAndView Cif = new ModelAndView();
	
	//추천게시글 이동
	@RequestMapping(value = "/recomm.do", method = RequestMethod.GET)
	public ModelAndView home(Locale locale, Model model) {
		logger.info("추천게시판 이동");
		mv.setViewName("body/recomm");
		return mv;
	}
	
	//관광지 정보 이동
	@RequestMapping(value = "/tocomm.do", method = RequestMethod.POST)
	public ModelAndView sub(String seq) {
		logger.info("관광지 정보로 이동");
		mv.setViewName("project/tocomm");
		mv.addObject("seq", seq);
		return mv;
	}
	
	//국가 정보 가져오기
	@RequestMapping(value = "/CNTinfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView CNTinfo() throws SQLException {
		logger.info("국가 정보 가져오기");
		Cif.setViewName("jsonView");
		ArrayList<HashMap<String, Object>> CNTinfos = areaService.CNTinfo();
		Cif.addObject("CNTinfos", CNTinfos);
		logger.info("Cif : "+Cif);
		return Cif;
	}
	
	
	//조회
	@RequestMapping(value = "/areaAllSelect.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView areaAllSelectInfo(@RequestBody HashMap<String, Object> hm) throws SQLException {
		logger.info("추천 여행지 조회중");
		mv.setViewName("jsonView");
		logger.info("받은값은 :"+hm);
		ArrayList<HashMap<String, Object>> list = areaService.areaAllSelectChk();

		mv.addObject("data", list);

		logger.info("mv="+mv);
		return mv;
	}
	
	
	//선택조회
	@RequestMapping(value = "/areaSelect.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView areaSelectInfo(@RequestBody HashMap<String, Object> hm) throws SQLException {
		System.out.println("0");
		mv.setViewName("jsonView");
		System.out.println("1");
		ArrayList<HashMap<String, Object>> list = areaService.areaSelectChk(hm);
		System.out.println("2");
		mv.addObject("data", list);
		System.out.println("3");
		System.out.println(mv);
		return mv;
	}
		
	//관광지 정보
	@RequestMapping(value = "/areaInfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView areaInfo(@RequestBody HashMap<String, Object> hm) throws SQLException {
		System.out.println("0");
		mv.setViewName("jsonView");
		System.out.println("1");
		ArrayList<HashMap<String, Object>> list = areaService.areaInfoChk(hm);
		System.out.println("2");
		mv.addObject("data", list);
		System.out.println("3");
		System.out.println(mv);
		return mv;
	}
	
	//selectBox
	@RequestMapping(value = "/selectBox.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView selectBox(@RequestBody HashMap<String, Object> hm) throws SQLException {
		System.out.println("0");
		mv.setViewName("jsonView");
		System.out.println("1");
		ArrayList<HashMap<String, Object>> list = areaService.selectBox();
		System.out.println("2");
		mv.addObject("data", list);
		System.out.println("3");
		System.out.println(mv);
		return mv;
	}
	
	//selectBox
	@RequestMapping(value = "/oneSelectBox.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView oneSelectBox(@RequestBody HashMap<String, Object> hm) throws SQLException {
		System.out.println("0");
		mv.setViewName("jsonView");
		System.out.println("1");
		HashMap<String, Object> list = areaService.oneSelectBox(hm);
		System.out.println("2");
		mv.addObject("data", list);
		System.out.println("3");
		System.out.println(mv);
		return mv;
	}
	
	
	
	//무한스크롤
	@RequestMapping(value="/infinityAreaLoding.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView infinityAreaLodingRB(@RequestBody HashMap<String, Object> map) throws SQLException {
		
		mv.setViewName("jsonView");
		logger.info("무한스크롤");
		try {
			logger.info("받은값은 :" +map);
			
			String keyword=(String)map.get("keyword");
			String searchType=(String)map.get("searchType");
			
			PagingVO vo = new PagingVO(0, (int) map.get("nowPage"), (int) map.get("cntPerPage"), keyword, searchType);
			
			int total = areaService.areaCount(vo);
			logger.info("조건을 만족하는 게시글의 수는 "+total);
			
			vo = new PagingVO(total, (int) map.get("nowPage"), (int) map.get("cntPerPage"), keyword, searchType);
			
			logger.info("vo는"+vo);
			mv.addObject("paging", vo);
			mv.addObject("viewAll", areaService.areaSelect(vo));
		} catch(Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		mv.addObject("success", "Y");
		logger.info("mv는"+mv);
		return mv;
	}
	
	//리뷰불러오기
	@RequestMapping(value = "/reviewSelect.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView reviewSelect(@RequestBody HashMap<String, Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		ArrayList<HashMap<String, Object>> list = areaService.reviewSelect(hm);
		mv.addObject("data", list);
		System.out.println("mv = " + mv);
		return mv;
	}
		

}

