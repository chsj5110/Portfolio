package a.a.a.ctr;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.HotelService;

@Controller
public class HotelController {
	private static final Logger logger = LoggerFactory.getLogger(HotelController.class);
	private ModelAndView mv = new ModelAndView();

	@Resource(name = "hotelService")
	private HotelService hotelService;
	private ModelAndView addObject;
	
	
	@RequestMapping(value = "/adminInserthotel.do", method = {RequestMethod.GET, RequestMethod.POST})
	public String home() {
		return "body/MapHotelAddInfo";
	}
	
	@RequestMapping(value = "project/selecthotelinfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView selecthotelinfo(@RequestBody HashMap<String, Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		
		
		ArrayList<HashMap<String, Object>> list = hotelService.selecthotelinfo(hm);
		System.out.println(list);
		mv.addObject("list", list);
		
		return mv;
	}
	

	@RequestMapping(value = "project/addhotelinfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView addhotelinfo(@RequestBody HashMap<String, Object> hm) throws SQLException {
		
		mv.setViewName("jsonView");
		
		boolean bol = hotelService.addhotelinfo(hm);
		
		mv.addObject("addInfo", bol);
		
		System.out.println("입력완료? = " + bol);
		
		return mv;
	}
	
	@RequestMapping(value = "/project/modifyhotelinfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView modifyhotelinfo(@RequestBody HashMap<String, Object> hm) throws SQLException {
		
		mv.setViewName("jsonView");
		
		boolean bol = hotelService.modifyhotelinfo(hm);
		
		mv.addObject("modifyInfo", bol);
		
		System.out.println("수정완료? = " + bol);
		
		return mv;
	}
	
	@RequestMapping(value = "/deletehotelinfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView deletehotelinfo(@RequestBody HashMap<String, Object> hm) throws SQLException {
		
		mv.setViewName("jsonView");
		
		boolean bol = hotelService.deletehotelinfo(hm);
		
		mv.addObject("deletehotelinfo", bol);
		
		System.out.println("삭제완료? = " + bol);
		
		return mv;
	}

	@RequestMapping(value = "/selecthotelinfo2.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView selecthotelinfo2(@RequestBody HashMap<String, Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		
		
		ArrayList<HashMap<String, Object>> list = hotelService.selecthotelinfo2(hm);
		System.out.println(list);
		mv.addObject("list", list);
		
		return mv;
	}
	
	
}
