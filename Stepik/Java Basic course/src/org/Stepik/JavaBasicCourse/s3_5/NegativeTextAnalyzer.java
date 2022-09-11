package org.Stepik.JavaBasicCourse.s3_5;

public class NegativeTextAnalyzer extends  KeywordAnalyzer {
    private String[] keywords;
    private Label label;
    public NegativeTextAnalyzer() {
        keywords = new String[] { ":(", "=(", ":|" };
        label = Label.NEGATIVE_TEXT;
    };

    @Override
    protected String[] getKeywords() {
        return keywords;
    }

    @Override
    protected Label getLabel() {
        return label;
    }
}
