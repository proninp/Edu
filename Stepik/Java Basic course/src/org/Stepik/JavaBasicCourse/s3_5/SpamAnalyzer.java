package org.Stepik.JavaBasicCourse.s3_5;

public class SpamAnalyzer extends KeywordAnalyzer {
    private String[] keywords;
    private Label label;
    public SpamAnalyzer(String[] keywords) {
        this.keywords = keywords;
        label = Label.SPAM;
    }

    @Override
    protected String[] getKeywords() {
        return keywords;
    }

    @Override
    protected Label getLabel() {
        return label;
    }
}
